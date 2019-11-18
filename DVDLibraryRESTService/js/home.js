$(document).ready(function () {
    $('#errorMessagesDiv').hide();
    $('#headerTitleDiv').hide();
    $('#searchDVDForm').show();
    $('#dvdDetailDiv').hide();
    $('#dvdTableDiv').show();

    loadDvds();

    $('#search-button').click(function (event) {
        $('#errorMessages').empty();
        $('#errorMessagesDiv').hide();

        var contentRows = $('#contentRows');
        var haveValidationErrors = checkAndDisplayValidationErrors($('#searchDVDForm').find('input'));

        if (haveValidationErrors) {
            $('#errorMessagesDiv').show();
            return false;
        }
        var category = $('#category').val();
        var term = $('#search-term').val();
        var isDigitOnly = /^\d+$/.test(term);

        if (category == null || term == ""){
            $('#errorMessagesDiv').show();
            $('#errorMessages').val("Both Search Category and Search Term are required.");
            return;

        }
        if (category === "Release Year" && term.length != 4) {
            $('#errorMessagesDiv').show();
            $('#errorMessages').val("Please enter a 4-digit year.");
            return;
        }
        if (category === "Release Year" && isDigitOnly == false) {
            $('#errorMessagesDiv').show();
            $('#errorMessages').val("Please enter digits only when searching for release year.");
            return;
        }

        clearDVDTable();

        if (category === "Title") {
            $.ajax ({
                type: 'GET',
                //url: 'http://localhost:8080/dvds/title/' + term,
                url: 'http://localhost:50748/dvds/title/' + term,
                success: function (data, status) {
                    $.each(data, function (index, dvd) {
                        var title = dvd.title;
                        var releaseYear = dvd.realeaseYear;
                        var director = dvd.director;
                        var rating = dvd.rating;
                        var notes = dvd.notes;
                        var id = dvd.dvdId;
        
                        var row = '<tr>';
                            row += '<td><a onclick="showDVDDetailForm(' + id + ')">' + title + '</a></td>';
                            row += '<td>' + releaseYear + '</td>';
                            row += '<td>' + director + '</td>';
                            row += '<td>' + rating + '</td>';
                            row += '<td><a onclick="showEditForm(' + id + ')">Edit</a> | <a onclick="deleteDVD(' + id + ')">Delete</a></td>';
                            row += '</tr>';
        
                        contentRows.append(row);
                    });
                },
                error: function() {
                    $('#errorMessages')
                        .append($('<li>')
                        .attr({class: 'list-group-item list-group-item-danger'})
                        .text('Error calling web service.  Please try again later.'));
                }
            });
        }

        if (category === "Release Year") {
            $.ajax ({
                type: 'GET',
                //url: 'http://localhost:8080/dvds/year/' + term,
                url: 'http://localhost:50748/dvds/year/' + term,

                success: function (data, status) {
                    $.each(data, function (index, dvd) {
                        var title = dvd.title;
                        var releaseYear = dvd.realeaseYear;
                        var director = dvd.director;
                        var rating = dvd.rating;
                        var notes = dvd.notes;
                        var id = dvd.dvdId;
        
                        var row = '<tr>';
                            row += '<td><a onclick="showDVDDetailForm(' + id + ')">' + title + '</a></td>';
                            row += '<td>' + releaseYear + '</td>';
                            row += '<td>' + director + '</td>';
                            row += '<td>' + rating + '</td>';
                            row += '<td><a onclick="showEditForm(' + id + ')">Edit</a> | <a onclick="deleteDVD(' + id + ')">Delete</a></td>';
                            row += '</tr>';
        
                        contentRows.append(row);
                    });
                },
                error: function() {
                    $('#errorMessages')
                        .append($('<li>')
                        .attr({class: 'list-group-item list-group-item-danger'})
                        .text('Error calling web service.  Please try again later.'));
                }
            });
        }

        if (category === "Director Name") {
            $.ajax ({
                type: 'GET',
                //url: 'http://localhost:8080/dvds/director/' + term,
                url: 'http://localhost:50748/dvds/director/' + term,

                success: function (data, status) {
                    $.each(data, function (index, dvd) {
                        var title = dvd.title;
                        var releaseYear = dvd.realeaseYear;
                        var director = dvd.director;
                        var rating = dvd.rating;
                        var notes = dvd.notes;
                        var id = dvd.dvdId;
        
                        var row = '<tr>';
                            row += '<td><a onclick="showDVDDetailForm(' + id + ')">' + title + '</a></td>';
                            row += '<td>' + releaseYear + '</td>';
                            row += '<td>' + director + '</td>';
                            row += '<td>' + rating + '</td>';
                            row += '<td><a onclick="showEditForm(' + id + ')">Edit</a> | <a onclick="deleteDVD(' + id + ')">Delete</a></td>';
                            row += '</tr>';
        
                        contentRows.append(row);
                    });
                },
                error: function() {
                    $('#errorMessages')
                        .append($('<li>')
                        .attr({class: 'list-group-item list-group-item-danger'})
                        .text('Error calling web service.  Please try again later.'));
                }
            });
        }

        if (category === "Rating") {
            $.ajax ({
                type: 'GET',
                //url: 'http://localhost:8080/dvds/rating/' + term,
                url: 'http://localhost:50748/dvds/rating/' + term,

                success: function (data, status) {
                    $.each(data, function (index, dvd) {
                        var title = dvd.title;
                        var releaseYear = dvd.realeaseYear;
                        var director = dvd.director;
                        var rating = dvd.rating;
                        var notes = dvd.notes;
                        var id = dvd.dvdId;
        
                        var row = '<tr>';
                            row += '<td><a onclick="showDVDDetailForm(' + id + ')">' + title + '</a></td>';
                            row += '<td>' + releaseYear + '</td>';
                            row += '<td>' + director + '</td>';
                            row += '<td>' + rating + '</td>';
                            row += '<td><a onclick="showEditForm(' + id + ')">Edit</a> | <a onclick="deleteDVD(' + id + ')">Delete</a></td>';
                            row += '</tr>';
        
                        contentRows.append(row);
                    });
                },
                error: function() {
                    $('#errorMessages')
                        .append($('<li>')
                        .attr({class: 'list-group-item list-group-item-danger'})
                        .text('Error calling web service.  Please try again later.'));
                }
            });   
        }
        else {
            $('#errorMessages').val("There is no match to your search category and term.");
            setTimeout(function(){
                $('#messages').val('');
                }, 3000)
            return;
        }
        $('#category').val('');
        $('#search-term').val('');
    });

    $('#add-new-dvd-button').click(function (event) {

        var haveValidationErrors = checkAndDisplayValidationErrors($('#create-dvd-form').find('input'));
        var title = $('#create-dvd-title').val();
        var rating = $('#create-rating').val();
        var year = $('#create-release-year').val();
        var isDigitOnly = /^\d+$/.test(year);

        if (haveValidationErrors) {
            $('#errorMessages').val("Please fill out the form.");
            return false;
        }

        if (isDigitOnly == false || year.length != 4) {
            $('#errorMessagesDiv').show();
            $('#errorMessages').val("Please enter a 4-digit year.");
            return;
        }
        if (title == null || title == "") {
            $('#errorMessagesDiv').show();
            $('#errorMessages').val("Please enter a title for the DVD.");
            return;
        }
        if (rating == null || rating == "") {
            $('#errorMessagesDiv').show();
            $('#errorMessages').val("Please choose a rating for the DVD.");
            return;
        }

        $.ajax({
            type: 'POST',
            //url: 'http://localhost:8080/dvd',
            url: 'http://localhost:50748/dvd',

            data: JSON.stringify({
                title: $('#create-dvd-title').val(),
                realeaseYear: $('#create-release-year').val(),
                director: $('#create-director').val(),
                rating: $('#create-rating').val(),
                notes: $('#create-notes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function(data, status) {
                $('#errorMessages').empty();
                hideCreateForm()
                loadDvds();
            },
            error: function() {
                $('#errorMessages')
                   .append($('<li>')
                   .attr({class: 'list-group-item list-group-item-danger'})
                   .text('Error calling web service.  Please try again later.'));
            }
        });
    });

    $('#edit-button').click(function (event) {

        var haveValidationErrors = checkAndDisplayValidationErrors($('#edit-dvd-form').find('input'));
        var year = $('#edit-release-year').val();
        var title = $('#edit-title').val();
        var isDigitOnly = /^\d+$/.test(year);

        if (haveValidationErrors) {
            $('#errorMessages').val("Please fill out the form.");
            return false;
        }
        if (isDigitOnly == false || year.length != 4) {
            $('#errorMessagesDiv').show();
            $('#errorMessages').val("Please enter a 4-digit year.");
            return;
        }
        if (title == null || title == "") {
            $('#errorMessagesDiv').show();
            $('#errorMessages').val("Please enter a title for the DVD.");
            return;
        }

        $.ajax({
           type: 'PUT',
           //url: 'http://localhost:8080/dvd/' + $('#edit-dvd-id').val(),
           url: 'http://localhost:50748/dvd/' + $('#edit-dvd-id').val(),

           data: JSON.stringify({
             dvdId: $('#edit-dvd-id').val(),
             title: $('#edit-title').val(),
             realeaseYear: $('#edit-release-year').val(),
             director: $('#edit-director').val(),
             rating: $('#edit-rating').val(),
             notes: $('#edit-notes').val()
           }),
           headers: {
             'Accept': 'application/json',
             'Content-Type': 'application/json'
           },
           'dataType': 'json',
            success: function() {
                $('#errorMessages').empty();
                hideEditForm();
                loadDvds();
           },
           error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
           }
       })
    });
});

function loadDvds() {

    clearDVDTable();

    var contentRows = $('#contentRows');

    $.ajax ({
        type: 'GET',
        //url: 'http://localhost:8080/dvds',
        url: 'http://localhost:50748/dvds',

        success: function (data, status) {
            $.each(data, function (index, dvd) {
                var title = dvd.title;
                var releaseYear = dvd.realeaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var notes = dvd.notes;
                var id = dvd.dvdId;

                var row = '<tr>';
                    row += '<td><a onclick="showDVDDetailForm(' + id + ')">' + title + '</a></td>';
                    row += '<td>' + releaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><a onclick="showEditForm(' + id + ')">Edit</a> | <a onclick="deleteDVD(' + id + ')">Delete</a></td>';
                    row += '</tr>';

                contentRows.append(row);
            });
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
        }
    });
}

function clearDVDTable() {
    $('#contentRows').empty();
}

function showDVDDetailForm(dvdId) {
    $('#errorMessages').empty();

    $.ajax({
        type: 'GET',
        //url: 'http://localhost:8080/dvd/' + dvdId,
        url: 'http://localhost:50748/dvd/' + dvdId,

        success: function(data, status) {
              $('#dvd-details-id').val(data.dvdId);
              $('#dvdDetailTitle').val(data.title);
              $('#details-release-year').val(data.realeaseYear);
              $('#details-director').val(data.director);
              $('#details-rating').val(data.rating);
              $('#details-notes').val(data.notes);
          },
          error: function() {
            $('#errorMessages')
               .append($('<li>')
               .attr({class: 'list-group-item list-group-item-danger'})
               .text('Error calling web service.  Please try again later.'));
          }
    }); 
    $('#headerTitleDiv').show();
    $('#dvdDetailDiv').show();
    $('#searchDVDForm').hide();
    $('#dvdTableDiv').hide();
}

function showCreateDVDForm() {
    // clear errorMessages
    $('#errorMessages').empty();

    $('#homePage').hide();
    $('#searchDVDForm').hide();
    $('#dvdTableDiv').hide();
    $('#createDVDDiv').show();
}

function showEditForm(dvdId) {
    // clear errorMessages
    $('#errorMessages').empty();

    $.ajax({
        type: 'GET',
        //url: 'http://localhost:8080/dvd/' + dvdId,
        url: 'http://localhost:50748/dvd/' + dvdId,

        success: function(data, status) {
              $('#edit-dvd-id').val(data.dvdId);
              $('#edit-title').val(data.title);
              $('#edit-release-year').val(data.realeaseYear);
              $('#edit-director').val(data.director);
              $('#edit-rating').val(data.rating);
              $('#edit-notes').val(data.notes);
          },
          error: function() {
            $('#errorMessages')
               .append($('<li>')
               .attr({class: 'list-group-item list-group-item-danger'})
               .text('Error calling web service.  Please try again later.'));
          }
    });
    $('#homePage').hide();
    $('#dvdTableDiv').hide();
    $('#editDVDDiv').show();
}

function hideEditForm() {
    // clear errorMessages
    $('#errorMessages').empty();
    $('#errorMessagesDiv').hide();
    $('#edit-title').val('');
    $('#edit-release-year').val('');
    $('#edit-director').val('');
    $('#edit-rating').val('');
    $('#edit-notes').val('');

    $('#homePage').show();
    $('#editDVDDiv').hide();
    $('#dvdTableDiv').show();
}

function hideCreateForm() {
    // clear errorMessages
    $('#errorMessages').empty();
    $('#errorMessagesDiv').hide();
    $('#create-dvd-title').val('');
    $('#create-release-year').val('');
    $('#create-director').val('');
    $('#create-rating').val('');
    $('#create-notes').val('');

    $('#homePage').show();
    $('#searchDVDForm').show();
    $('#createDVDDiv').hide();
    $('#dvdTableDiv').show();
}

function hideDVDDetailForm() {
    $('#errorMessages').empty();
    $('#errorMessagesDiv').hide();
    $('#dvdDetailTitle').val('');
    $('#details-release-year').val('');
    $('#details-director').val('');
    $('#details-rating').val('');
    $('#details-notes').val('');

    $('#headerTitleDiv').hide();
    $('#searchDVDForm').show();
    $('#dvdDetailDiv').hide();
    $('#dvdTableDiv').show();
}

function deleteDVD(dvdId) {

    var response = confirm("Are you sure you want to delete this DVD from your collection?");

    if (response === true) {
        $.ajax ({
            type: 'DELETE',
            //url: "http://localhost:8080/dvd/" + dvdId,
            url: "http://localhost:50748/dvd/" + dvdId,

            success: function (status) {
                loadDvds();
            }
        });
    }
    else {
        
    }
}

function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();

    var errorMessages = [];

    // loop through each input and check for validation errors
    input.each(function() {
        // Use the HTML5 validation API to find the validation errors
        if(!this.validity.valid)
        {
            $('#errorMessagesDiv').show();
            var errorField = $('label[for='+this.id+']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0){
        $('#errorMessagesDiv').show();
        $.each(errorMessages,function(index,message){
            $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
    });
        return true;
    }
    else {
        return false;
    }
}
