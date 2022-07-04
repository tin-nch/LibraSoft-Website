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
        $.ajax({
            url: "/Event/RegisterEvent",
            dataType: "json",

            data: registerForm,

            success: function (rs) {


                if (rs == 1) {
                    Swal.fire({
                        title: 'Success!!',
                        text: "Submit successfully. Please check your email for more information",
                        icon: 'success',

                        showDenyButton: false,



                        confirmButtonText: 'OK'

                    });

                }
              else  if (rs == 0) {
                    Swal.fire({
                        title: 'Fail',
                        text: "Submi fail.You have submited this event",
                        icon: 'error',

                        showDenyButton: false,



                        confirmButtonText: 'OK'

                    });
                }

                else {
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
                alert("Not receiving data!");
            }
        })

    })})