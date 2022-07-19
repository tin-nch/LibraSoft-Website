$(document).ready(function () {

    $('#btnContactSubmit').click(function ()
    {

        var name = $('#cfFullName').val();
        var phone = $('#cfPhone').val();
        var email = $('#cfEmail').val();
        var reason = $('#cfReason').val();
        var message = $('#cfMessage').val();

        var contactForm = {
            FullName: name,
            Email: email,
            Phone: phone,
            ReasonReachingId: reason,
            MessageContent: message
        }

        if (name == '' && phone == '' && email == '' && reason == 0) {
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

        else if (reason == 0) {
            Swal.fire({
                title: 'Failure!!',
                text: "Please select reason",
                icon: 'error',
                showDenyButton: false,
                confirmButtonText: 'OK'
            })
            return false;
        }

        else {

            $.ajax({
                type: 'POST',
                url: "/Front/SaveContactForm",
                dataType: "json",
                data: contactForm,
                success: function (rs) {
                    if (rs == 1) {
                        $('#formContactVal')[0].reset();
                        Swal.fire({
                            title: 'Success!!',
                            text: "Submit successfully. Please check your email for more information",
                            icon: 'success',
                            showDenyButton: false,
                            confirmButtonText: 'OK'
                        });
                    }
                    else if (rs == 0) {
                        Swal.fire({
                            title: 'Failure!!',
                            text: "Submit fail.You already wrote this message",
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
                    alert("Not receiving data");
                }
            })
        }
    })
})