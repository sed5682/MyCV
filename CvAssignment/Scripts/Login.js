function checkPassword() {
    var pass = document.getElementById('Password').value;
    //var regex = new RegExp("^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{9,})");
    var regexCapital = new RegExp("(?=.*[A-Z])");
    var regexSmall = new RegExp("(?=.*[a-z])");
    var regexSpecial = new RegExp("(?=.[!@#\$%\^&])");
    var regexLength = new RegExp("(?=.{9,})");
    var regexNumbers = new RegExp("(?=.*[0-9])");


    if (!regexCapital.test(pass)) {
        document.getElementById('errorPassword').innerHTML = "do not contain Capital Letters";
        AddClass(false);
    }
    else if (!regexSmall.test(pass)) {
        document.getElementById('errorPassword').innerHTML = "do not contain Small Letters";
        AddClass(false);

    }
    else if (!regexNumbers.test(pass)) {
        document.getElementById('errorPassword').innerHTML = "do not contain Numbers";
        AddClass(false);

    }
    else if (!regexSpecial.test(pass)) {
        document.getElementById('errorPassword').innerHTML = "do not contain Special Characters";
        AddClass(false);

    }
    else if (!regexLength.test(pass)) {
        document.getElementById('errorPassword').innerHTML = "must be at least 9 characters";
        AddClass(false);

    }
    else {
        document.getElementById('errorPassword').innerHTML = "";
        AddClass(true);

    }

}
function AddClass(check) {
    if (check == true) {
        document.getElementById('btnSubmit').classList.remove('btnDisable');
        document.getElementById('btnSubmit').classList.add('btnEnable');
    }
    else {
        document.getElementById('btnSubmit').classList.add('btnDisable');
        document.getElementById('btnSubmit').classList.remove('btnEnable');
    }
}