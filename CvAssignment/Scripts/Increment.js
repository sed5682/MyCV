function AddModule() {

    var ModuleDiv = document.querySelector(".Education-fields");
     var node = ModuleDiv.cloneNode(true);
    document.getElementById("maincontent").appendChild(node);
};


function SaveEducation() {
    var EducationArray = [];
    var ModuleDiv = document.querySelectorAll('.Education-fields');


    for (var i = 0; i < ModuleDiv.length; i++) {
        EducationArray.push({
            Institution_Name: document.querySelectorAll(".Institution_Name")[i].value,
            Q_Name: document.querySelectorAll(".Qualification")[i].value,
            Course_Name: document.querySelectorAll(".Course_Name")[i].value,
            Module_Name: document.querySelectorAll(".Module_Name")[i].value,
            Module_Marks: document.querySelectorAll(".Module_Marks")[i].value,
            Module_Level: document.querySelectorAll(".Module_Level")[i].value
        });
    }


    

    $.ajax(
        {
            type: "Post",
            url: "/Admin/SaveEducationDetails",

            data: {
                EducationModel: EducationArray,

            },
          
            cache: false,
            success: function (data) {

                window.location.href = "/Admin/CreateNewUser";
            }

        });


}