$(function () {
    var email = $("#email");
    var username = $("#username");
    var signupform = $("#signupform");
    var loginform = $("#loginform");
    username.change(function() {
        if (!hasWhiteSpace(username.val())) {
            $("#error").text("");
            $.ajax({
                type: "GET",
                url: "/api/user/usernameexits",
                data: { username: username.val() },
                cache: false,
                success: function(data) {
                    if (data) {
                        $("#error").text("Username Already Exists");
                    } else {
                        $("#error").text("");
                    }
                }
            });
        } else {
            $("#error").text("Username don't have a white space");
        }
    });
    email.change(function() {
        if (!hasWhiteSpace(username.val())) {
            $("#error").text("");
            $.ajax({
                type: "GET",
                url: "/api/user/emailexits",
                data: { email: email.val() },
                cache: false,
                success: function(data) {
                    if (data) {
                        $("#error").text("Email Already Exists");
                    } else {
                        $("#error").text("");
                    }
                }
            });
        }
    });
    signupform.validate({
        rules: {
            Username: {
                required: true
            },
            Email: {
                required: true,
                email: true
            },
            Password: {
                required: true,
                minlength: 6
            }
        }
    });
    loginform.validate({
        rules: {
            Email: {
                required: true
            },
            Password: {
                required: true
            }
        }
    });

});
$(document).ready(function () {
    $("input[type=text]").val("");
    $("input[type=password]").val("");
});
function hasWhiteSpace(s) {
    return /\s/g.test(s);
}

