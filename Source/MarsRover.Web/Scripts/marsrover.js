$(function () {
    $('#newrover').on('click', function (e) {
        e.preventDefault();

        var i = $("#rovertable > tbody > tr").length;
        console.log(i.toString());
        $("<tr></tr>")
            .append($("<td></td>").append($("<input></input>", { "class": "text-box single-line", "data-val": "true", "data-val-number": "The field X Axis must be a number.", "data-val-required": "The X Axis field is required.", id: "Rovers_" + i.toString() + "__InputLocation_X", name: "Rovers[" + i.toString() + "].InputLocation.X", type: "number" })))
            .append($("<td></td>").append($("<input></input>", { "class": "text-box single-line", "data-val": "true", "data-val-number": "The field Y Axis must be a number.", "data-val-required": "The Y Axis field is required.", id: "Rovers_" + i.toString() + "__InputLocation_Y", name: "Rovers[" + i.toString() + "].InputLocation.Y", type: "number" })))
            .append($("<td></td>").append($("<select></select>", { "data-val": "true", "data-val-required": "The Direction field is required.", id: "Rovers_" + i.toString() + "__InputLocation_Orientation", name: "Rovers[" + i.toString() + "].InputLocation.Orientation" })
                .append($("<option></option>", { value: "1" }).text("N"))
                .append($("<option></option>", { value: "2" }).text("E"))
                .append($("<option></option>", { value: "3" }).text("S"))
                .append($("<option></option>", { value: "4" }).text("W"))))
            .append($("<td></td>").append($("<input></input>", { "class": "text-box single-line", "data-val": "true", "data-val-required": "The Commands field is required.", id: "Rovers_" + i.toString() + "__Commands", name: "Rovers[" + i.toString() + "].Commands", type: "text", "value": "" })))
            .append($("<td></td>").append($("<input></input>", { "class": "text-box single-line", "data-val": "true", "data-val-number": "The field X Axis must be a number.", id: "Rovers_" + i.toString() + "__OutputLocation_X", name: "Rovers[" + i.toString() + "].OutputLocation.X", type: "number" })))
            .append($("<td></td>").append($("<input></input>", { "class": "text-box single-line", "data-val": "true", "data-val-number": "The field Y Axis must be a number.", id: "Rovers_" + i.toString() + "__OutputLocation_Y", name: "Rovers[" + i.toString() + "].OutputLocation.Y", type: "number" })))
            .append($("<td></td>").append($("<select></select>", { "data-val": "true", id: "Rovers_" + i.toString() + "__OutputLocation_Orientation", name: "Rovers[" + i.toString() + "].OutputLocation.Orientation" })
                .append($("<option></option>", { value: "1" }).text("N"))
                .append($("<option></option>", { value: "2" }).text("E"))
                .append($("<option></option>", { value: "3" }).text("S"))
                .append($("<option></option>", { value: "4" }).text("W"))))
        .appendTo($("#rovertable > tbody"));
    });
});