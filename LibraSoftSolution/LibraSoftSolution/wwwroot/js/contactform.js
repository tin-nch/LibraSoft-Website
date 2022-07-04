$(document).ready(function () {

    $('#btnContactSubmit').click(function () {
        event.preventDefault();

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
        $.ajax({
            url: "/Home/SaveContactForm",
            dataType: "json",
            data: contactForm,
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

    })
})