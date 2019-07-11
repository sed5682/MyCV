function AddNewSkills() {



                //window.location.href = "/Admin/CreateNewUser";
                //document.getElementById('Saved').innerHTML = "Successfully Saved";
                var ModuleDiv = document.querySelector(".skills-container");
                var node = ModuleDiv.cloneNode(true);
                document.getElementById("skills-main").appendChild(node);
    
};


function SaveSkills() {

    var TodaysDate = new Date();
    var EffectiveStart = new Date(document.querySelector('.EffectiveStart').value);
    var EffectiveEnd = new Date(document.querySelector('.EffectiveEnd').value);
    var message = "";

    if ((EffectiveStart > TodaysDate) || (EffectiveStart > EffectiveEnd)) {
        message = "Your Start Date exceeds actual or End Date";
        document.getElementById('DateError').innerHTML = message;
        return;
    }
    if ((EffectiveEnd > TodaysDate)) {
        message = "Your End Date exceeds actual Date or is less than Start Date";
        document.getElementById('DateError').innerHTML = message;
        return;

    }
    var skillsID = document.querySelector(".SkillsID").value;
    //var SkillsArray = [];
    //var ModuleDiv = document.querySelectorAll('.skills-container');


    //for (var i = 0; i < ModuleDiv.length; i++) {
        //SkillsArray.push({
        //    SkillsID: document.querySelector(".SkillsID").value,
        //    EffectiveStart: EffectiveStart,
        //    EffectiveEnd: EffectiveEnd
        //});

    var startDate = EffectiveStart.toDateString();
    var endDate = EffectiveEnd.toDateString();

    $.ajax(
        {
            type: "Post",
            url: "/Admin/SaveSkills",

            data: {
                skillsID: skillsID,
                Start: startDate,
                End: endDate

            },

            cache: false,
            success: function (data) {

                //window.location.href = "/Admin/CreateNewUser";
                document.getElementById('Saved').innerHTML = data;
                RefreshSkills();
            }

        });


}


function SaveNewSkills() {
    var TodaysDate = new Date();
    var EffectiveStart = new Date(document.querySelector('.Start').value);
    var EffectiveEnd = new Date(document.querySelector('.End').value);
    var message = "";

    if ((EffectiveStart > TodaysDate) || (EffectiveStart > EffectiveEnd)) {
        message = "Your Start Date exceeds actual or End Date";
        document.getElementById('DateError').innerHTML = message;
        return;
    }
    if ((EffectiveEnd > TodaysDate)) {
        message = "Your End Date exceeds actual Date or is less than Start Date";
        document.getElementById('DateError').innerHTML = message;
        return;

    }

    var newSkill = document.getElementById('NewSkillText').value;
    var startDate = EffectiveStart.toDateString();
    var endDate = EffectiveEnd.toDateString();

    $.ajax(
        {
            type: "Post",
            url: "/Admin/CreateNewSkill",

            data: {
                SkillName: newSkill,
                Start: startDate,
                End: endDate

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

function DeleteSkills(SkillsToDelete) {
   


    $.ajax(
        {
            type: "Post",
            url: "/Admin/DeleteSkill",

            data: {
                SkillsName: SkillsToDelete,

            },

            cache: false,
            success: function (data) {
                document.getElementById('Saved').innerHTML = data;
               // AddNewSkillsDropDown();
                RefreshSkills();
            }

        });
}