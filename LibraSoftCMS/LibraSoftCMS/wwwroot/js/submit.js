$(document).ready(function () {

    $('#btnSubmitForm').click(function () {
        
        var email = $('#sfEmail').val();
        var idevent = $('#txtIDEvent').val();

        var submitForm = {
            Email: email,
            IDEvent: idevent
        }

        if (email == '') {
            Swal.fire({
                title: 'Failure!!',
                text: "Email is required",
                icon: 'error',
                showDenyButton: false,
                confirmButtonText: 'OK'
            })
            return false;
        }

        else {
            $.ajax({
                url: "/SubmitForm/CheckSubmit",
                dataType: "json",

                data: submitForm,

                success: function (rs) {
                    if(rs == 1) {
                    $('#submit-form')[0].reset();
                    $("#submitModal").modal("show");
            }
                    else if (rs == 0) {
                        $('#submit-form')[0].reset();
                        $("#submitModal").modal("show");
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
        }
    })
})