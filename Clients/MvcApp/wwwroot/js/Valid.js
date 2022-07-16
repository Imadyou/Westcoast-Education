function validateemail() {
    var x = document.myform.email.value;
    var atposition = x.indexOf("@");
    var dotposition = x.lastIndexOf(".");
    if (x == null || x == "") {
        alert("Name can't be blank");
        return false;
    }
    if (atposition < 1 || dotposition < atposition + 2 || dotposition + 2 >= x.length) {
        alert("Please enter a valid e-mail address \n atpostion:" + atposition + "\n dotposition:" + dotposition);
        return false;
    }
}

function matchpass() {
    var firstpassword = document.f1.password.value;
    var secondpassword = document.f1.password2.value;

    if (firstpassword == secondpassword) {
        return true;
    } else {
        alert("password must be same!");
        return false;
    }
}