function approveSTD(userID) {
    var approveModal = $('#approveModal');    
    approveModal.modal('show');

    $("#approveBtn").click(function (e) {
        e.preventDefault();
        approveModal.modal('hide');
        $.ajax({
            type: "POST",
            url: "/Student/ApproveStudent",
            data: { id: userID },
            success: function (response) {
                var generalModal = $('#generalSTDModal');
                generalModal.find('.modal-body').text("Record Updated Successfully!");
                generalModal.modal('show');
                setTimeout(function () {
                    window.location.href = response.redirectToUrl;
                }, 2000);
            },
            error: function () {
                var generalModal = $('#generalSTDModal');
                generalModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
                generalModal.modal('show');
            }
        });
    });    
}

function deleteSTD(userID) {
    var deleteModal = $('#deleteModal');
    deleteModal.modal('show');

    $("#deleteBtn").click(function (e) {
        e.preventDefault();
        deleteModal.modal('hide');
        $.ajax({
            type: "POST",
            url: "/Student/DeleteStudent",
            data: { id: userID },
            success: function (response) {
                var generalModal = $('#generalSTDModal');
                generalModal.find('.modal-body').text("Record Deleted Successfully!");
                generalModal.modal('show');
                setTimeout(function () {
                    window.location.href = response.redirectToUrl;
                }, 2000);
            },
            error: function () {
                var generalModal = $('#generalSTDModal');
                generalModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
                generalModal.modal('show');
            }
        });
    });
}