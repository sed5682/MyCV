function AddNewSkills() {



                //window.location.href = "/Admin/CreateNewUser";
                //document.getElementById('Saved').innerHTML = "Successfully Saved";
                var ModuleDiv = document.querySelector(".skills-container");
                var node = ModuleDiv.cloneNode(true);
                document.getElementById("skills-main").appendChild(node);
    
};


function SaveSkills() {
    var SkillsArray = [];
    var ModuleDiv = document.querySelectorAll('.skills-container');


    for (var i = 0; i < ModuleDiv.length; i++) {
        SkillsArray.push({
            SkillsID: document.querySelectorAll(".SkillsID")[i].value
        });
    }




    $.ajax(
        {
            type: "Post",
            url: "/Admin/SaveSkills",

            data: {
                SkillsModel: SkillsArray,

            },

            cache: false,
            success: function (data) {

                //window.location.href = "/Admin/CreateNewUser";
                document.getElementById('Saved').innerHTML = data;
                RefreshSkills();
            }

        });


}


function SaveNewSkills(){
    var newSkill = document.getElementById('NewSkillText').value;

    $.ajax(
        {
            type: "Post",
            url: "/Admin/CreateNewSkill",

            data: {
                SkillName: newSkill,

            },

            cache: false,
            success: function (data) {

                //window.location.href = "/Admin/CreateNewUser";
                document.getElementById('Saved').innerHTML = data;
                AddNewSkillsDropDown();
                RefreshSkills();

            }

        });
}