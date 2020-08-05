// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the movie create form.
    // It has the name attribute "moviecreate"
    $("form[name='moviecreate']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            Title: {
                required: true,
                minlength: 2
            },
            YearOfRelease: "required",
            GenreID: {
                required: true,
                min: 1
            },
            DirectorID: {
                required: true,
                min: 1
            },
            Price: {
                required: true,
                number: true,
                min: 1
            },
            IMBDScore: {
                required: true,
                number: true,
                min: 1
            },
            Language: "required",
            Country: "required",
            Description: "required"
            
        },
        // Specify validation error messages
        messages: {
            Title: {
                required: "Please enter your Movie name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            YearOfRelease: "Please enter the year of release",

            GenreID: {
                required: "Please choose genre",
                min: "Please select one genre from the dropdown"
            },
            DirectorID: {
                required: "Please choose director",
                min: "Please select one director from the dropdown"
            },
            Price: {
                required: "Please enter the price of the movie",
                number: "Please enter decimal numbers only",
                min: jQuery.validator.format("At least number {0} required")
                
            },
            IMBDScore: {
                required: "Please enter the price of the movie",
                number: "Please enter decimal numbers only",
                min: jQuery.validator.format("At least number {0} required")
                
            },
            Language: "Please enter movie language",
            Country: "Please enter country of origin",
            Description: "Please enter description"
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});
// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the genre create form.
    // It has the name attribute "genrecreate"
    $("form[name='genrecreate']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            Name: {
                required: true,
                minlength: 2
            }

        },
        // Specify validation error messages
        messages: {
            Name: {
                required: "Please enter your genre name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            }
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});
$(function () {
    // Initialize form validation on the genre create form.
    // It has the name attribute "genrecreate"
    $("form[name='genreedit']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            Name: {
                required: true,
                minlength: 2
            }

        },
        // Specify validation error messages
        messages: {
            Name: {
                required: "Edit your genre name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            }
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});
// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the director create form.
    // It has the name attribute "directorcreate"
    $("form[name='directorcreate']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            Name: {
                required: true,
                minlength: 2
            },
            Country: "required"

        },
        // Specify validation error messages
        messages: {
            Name: {
                required: "Please enter your Director name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
           
            Country: "Please enter country of origin"
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});
// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the director create form.
    // It has the name attribute "directorcreate"
    $("form[name='directoredit']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            Name: {
                required: true,
                minlength: 2
            },
            Country: "required"

        },
        // Specify validation error messages
        messages: {
            Name: {
                required: "Edit your Director name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
           
            Country: "Edit your country of origin"
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});
$(function () {
    // Initialize form validation on the user create form.
    // It has the name attribute "usercreate"
    $("form[name='usercreate']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            Name: {
                required: true,
                minlength: 2
            },
            Email: "required",
            Password: "required",
            RoleID: {
                required: true,
                min: 1
            }

        },
        // Specify validation error messages
        messages: {
            Name: {
                required: "Please enter your User name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },

            Email: "Please enter the email address",
            Password: "Please enter the password",
            RoleID: {
                required: "Please choose the role of the User",
                min: "Please select one role from the dropdown"
            }
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});
$(function () {
    // Initialize form validation on the user create form.
    // It has the name attribute "usercreate"
    $("form[name='useredit']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            Name: {
                required: true,
                minlength: 2
            },
            Email: "required",
            Password: "required",
            RoleID: {
                required: true,
                min: 1
            }

        },
        // Specify validation error messages
        messages: {
            Name: {
                required: "Edit your User name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },

            Email: "Edit your email address",
            Password: "Change your password",
            RoleID: {
                required: "Please choose your new role",
                min: "Please select one role from the dropdown"
            }
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});