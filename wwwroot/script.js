function getUsers() {
    $.ajax({
        url: '/api/users',
        method: 'GET',
        success: function (data) {
            var users = data.seznam;
            var tableBody = $('#userTable tbody');
            tableBody.empty();

            users.forEach(function (user) {
                var row = $('<tr>');
                row.append('<td>' + user.ime + '</td>');
                row.append('<td>' + user.starost + '</td>');
                tableBody.append(row);
            });
        },
        error: function () {
            alert('Prišlo je do napake pri pridobivanju podatkov.');
        }
    });
}

function addUserLocally(ime, starost) {
    var tableBody = $('#userTable tbody');
    var row = $('<tr>');
    row.append('<td>' + ime + '</td>');
    row.append('<td>' + starost + '</td>');
    tableBody.append(row);
}

function addUserToServer(ime, starost) {
    $.ajax({
        url: '/api/users',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ ime: ime, starost: starost }),
        success: function (data) {
            getUsers();
        },
        error: function () {
            alert('Prišlo je do napake pri dodajanju podatkov na strežnik.');
        }
    });
}

$(document).ready(function() {
    getUsers();

    $("#userForm").submit(function (event) {
        event.preventDefault();

        var ime = $('#ime').val();
        var starost = $('#starost').val();

        if (event.originalEvent.submitter.id === 'localButton') {
            addUserLocally(ime, starost);
        } else if (event.originalEvent.submitter.id === 'serverButton') {
            addUserToServer(ime, starost);
        }

        $('#ime').val('');
        $('#starost').val('');
    });
});

