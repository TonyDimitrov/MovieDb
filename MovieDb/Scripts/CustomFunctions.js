    $("#LoadingStatus").html("Loading....");
    $.get("/Home/GetMovies", null, DataBind);
    function DataBind(Movies) {
        var SetData = $("#SetMovieList");
        for (var i = 0; i < Movies.length; i++) {
            var Data = "<tr class='row_" + Movies[i].Id + "'>" +
                "<td>" + "<a href='#' class='btn btn-warning' onclick='EditMovie(" + Movies[i].Id + ")' ><span class='glyphicon glyphicon-edit'></span></a>" + "</td>" +
                "<td>" + "<a href='#' class='btn btn-danger' onclick='DetailsMovie(" + Movies[i].Id + ")'><span class='glyphicon glyphicon-info-sign'></span></a>" + "</td>" +
                "<td>" + Movies[i].Id + "</td>" +
                "<td>" + Movies[i].Title + "</td>" +
                "<td>" + Movies[i].DirectorName + "</td>" +
                "<td>" + ToJavaScriptDate(Movies[i].ReleaseDate) + "</td>" +
                "</tr>";
            SetData.append(Data);
            $("#LoadingStatus").html(" ");

        }
    }

    //Show The Popup Modal For Add New Movie

    function AddNewMovie() {
        $("#SubmitForm").prop("disabled", false);
        $("#SaveMovie").show();
        $("#form")[0].reset();
        $("#MovieId").val(0);
        $("#ModalTitle").html("Add Movie");
        $("#MyModal").modal();

    }

    // Convert DateTime

    function ToJavaScriptDate(value) {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));
        return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
    }

    // Save new movie
    $('#SaveMovie').click(function () {
        var url = "/Home/SaveNewMovie";

        $.ajax({
            url: url,
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                Id: $("#MovieId").val(),
                Title: $("#MovTitle").val(),
                DirectorName: $("#MovDirector").val(),
                ReleaseDate: $("#MovReleaseDate").val()
            }),
            success: 'ok',
        
            error: 'fail'
    });
        return false;
    });

    //Show The Popup Modal For Edit Student Record

    function EditMovie(Id) {
        var url = "/Home/GetMovie?Id=" + Id;
        $("#ModalTitle").html("Edit Movie");
        $("#MyModal").modal();
        $.ajax({
            type: "GET",
            url: url,
            success: function (obj) {
                $("#SubmitForm").prop("disabled", false);
                $("#MovieId").val(obj.Id);
                $("#MovTitle").val(obj.Title);
                $("#MovDirector").val(obj.DirectorName);
                $("#MovReleaseDate").val(ToJavaScriptDate(obj.ReleaseDate));
            }
        })
        $("#SaveMovie").show();
    }

    function DetailsMovie(Id) {
        var url = "/Home/GetMovie?Id=" + Id;
        $("#ModalTitle").html("Details");
        $("#MyModal").modal();
        $.ajax({
            type: "GET",
            url: url,
            success: function (obj) {
                $("#SubmitForm").prop("disabled", true);
                $("#MovieId").val(obj.Id);
                $("#MovTitle").val(obj.Title);
                $("#MovDirector").val(obj.DirectorName);
                $("#MovReleaseDate").val(ToJavaScriptDate(obj.ReleaseDate));
            }
        })
        $("#SaveMovie").hide();

    }