var $loading = $('#loaderIcon').hide();
$(document)
    .ajaxStart(function () {
        $loading.show();
    })
    .ajaxStop(function () {
        $loading.hide();
    });

$(document).ready(function () {

    $('#btnEventSubmit').click(function () {
        var name = $('#txtName').val();
        var email = $('#txtEmail').val();
        var phone = $('#txtPhone').val();
        var companyname = $('#txtCompanyName').val();
        var position = $('#txtPosition').val();
        var idevent = $('#txtIDEvent').val();

        var registerForm = {
            FullName: name,
            Phone: phone,
            Email: email,
            CompanyName: companyname,
            Position: position,
            IDEvent: idevent
        }

        if (name == '' && phone == '' && email == '' && companyname == '' && position == '') {
            Swal.fire({
                title: 'Failure!!',
                text: "Enter all fields",
                icon: 'error',
                showDenyButton: false,
                confirmButtonText: 'OK'
            })
            return false;
        }

        else if (name == '') {
            Swal.fire({
                title: 'Failure!!',
                text: "Please enter your name",
                icon: 'error',
                showDenyButton: false,
                confirmButtonText: 'OK'
            })
            return false;
        }

        else if (phone == '') {
            Swal.fire({
                title: 'Failure!!',
                text: "Please enter your phone number",
                icon: 'error',
                showDenyButton: false,
                confirmButtonText: 'OK'
            })
            return false;;
        }

        else if (email == '') {
            Swal.fire({
                title: 'Failure!!',
                text: "Email is required",
                icon: 'error',
                showDenyButton: false,
                confirmButtonText: 'OK'
            })
            return false;
        }

        else if (companyname == '') {
            Swal.fire({
                title: 'Failure!!',
                text: "Please enter your company name",
                icon: 'error',
                showDenyButton: false,
                confirmButtonText: 'OK'
            })
            return false;
        }

        else if (position == '') {
            Swal.fire({
                title: 'Failure!!',
                text: "Please enter your position",
                icon: 'error',
                showDenyButton: false,
                confirmButtonText: 'OK'
            })
            return false;
        }

        else {
            $.ajax({
                url: "/Event/RegisterEvent",
                dataType: "json",

                data: registerForm,

                success: function (rs) {

                    $('#loaderIcon').show();
                    if (rs == 1) {
                        $('#loaderIcon').hide();
                        $('#OTPInput').hide();
                        $('#event-form')[0].reset();
                        Swal.fire({
                            title: 'Success!!',
                            text: "Submit successfully. Please check your email for more information",
                            icon: 'success',
                            showDenyButton: false,
                            confirmButtonText: 'OK'
                        });

                    }
                    else if (rs == 0) {
                        $('#loaderIcon').hide();
                        Swal.fire({
                            title: 'Fail',
                            text: "Submi fail.You have submited this event",
                            icon: 'error',

                            showDenyButton: false,
                            confirmButtonText: 'OK'

                        });
                    }
                    else {
                        $('#loaderIcon').hide();
                        Swal.fire({
                            title: 'Failure!!',
                            text: "Please enter the full information",
                            icon: 'error',
                            showDenyButton: false,
                            confirmButtonText: 'OK'

                        });
                    }
                },
                error: function () {
                    $('.loading').hide();
                    alert("Not receiving data!");
                }
            })

        }
    })
})