window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Operation successful', { timeOut: 5000 })
    }
    if (type === "error") {
        toastr.error(message, 'Operation failed', { timeOut: 5000 })
    }
}

window.ShowAlert = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Good job!',
            'You clicked the button!',
            'success'
        )
    }
    if (type === "error") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
            footer: '<a href="">Why do I have this issue?</a>'
        })
    }
}