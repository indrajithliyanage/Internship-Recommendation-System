function approveCGU(CGUnitID) {
    var cguapproveModal = $('#cguapproveModal');   
    cguapproveModal.modal('show');

    $("#approveBtn").click(function (e) {
        e.preventDefault();
        cguapproveModal.modal('hide');
        $.ajax({
            type: "POST",
            url: "/CGU/ApproveCGU",
            data: { id: CGUnitID },
            success: function (response) {
                var cguGeneralModal = $('#cguGeneralModal');
                cguGeneralModal.find('.modal-body').text("Record Updated Successfully!");
                cguGeneralModal.modal('show');
                setTimeout(function () {
                    window.location.href = response.redirectToUrl;
                }, 2000);
            },
            error: function () {
                var cguGeneralModal = $('#cguGeneralModal');
                cguGeneralModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
                cguGeneralModal.modal('show');
            }
        });
    });
}

function deleteCGU(CGUnitID) {
    var cguDeleteModal = $('#cguDeleteModal');
    cguDeleteModal.modal('show');

    $("#deleteBtn").click(function (e) {
        e.preventDefault();
        cguDeleteModal.modal('hide');
        $.ajax({
            type: "POST",
            url: "/CGU/DeleteCGU",
            data: { id: CGUnitID },
            success: function (response) {
                var cguGeneralModal = $('#cguGeneralModal');
                cguGeneralModal.find('.modal-body').text("Record Deleted Successfully!");
                cguGeneralModal.modal('show');
                setTimeout(function () {
                    window.location.href = response.redirectToUrl;
                }, 2000);
            },
            error: function () {
                var cguGeneralModal = $('#cguGeneralModal');
                cguGeneralModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
                cguGeneralModal.modal('show');
            }
        });
    });
}