using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MarsRover.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class EnsureMinimumElementsAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly int _minElements;
        public EnsureMinimumElementsAttribute(int minElements)
        {
            _minElements = minElements;
        }

        public override bool IsValid(object value)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Running validation for {0}", value.GetType()));
            var list = value as IList;
            if (list != null)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("List has {0} elements and the minimum is {1}", list.Count, _minElements));
                return list.Count >= _minElements;
            }
            return false;
        }

        #region Overrides of ValidationAttribute

        /// <summary>Validates the specified value with respect to the current validation attribute.</summary>
        /// <returns>An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class. </returns>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Running validation for {0}", value.GetType()));
            var list = value as IList;
            if (list != null)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("List has {0} elements and the minimum is {1}", list.Count, _minElements));
                if (list.Count >= _minElements)
                {
                    return ValidationResult.Success;
                }

                var memberNameList = new List<string>();
                if (validationContext.MemberName != null)
                {
                    memberNameList.Add(validationContext.MemberName);
                }

                if (!string.IsNullOrEmpty(this.ErrorMessage))
                {
                    return new ValidationResult(this.ErrorMessage, memberNameList);
                }
                else
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName), memberNameList);
                }
            }

            return base.IsValid(value, validationContext);
        }

        #endregion

        #region Implementation of IClientValidatable

        /// <summary>When implemented in a class, returns client validation rules for that class.</summary>
        /// <returns>The client validation rules for this validator.</returns>
        /// <param name="metadata">The model metadata.</param>
        /// <param name="context">The controller context.</param>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = this.FormatErrorMessage(metadata.DisplayName);
            rule.ValidationType = "listlength";

            yield return rule;
        }

        #endregion
    }
}
