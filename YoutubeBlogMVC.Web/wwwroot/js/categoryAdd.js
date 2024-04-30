$(document).ready(function () {
    $("#btnSave").click(function (event) {
        event.preventDefault();

        const addUrl = app.Urls.categoryAddUrl
        const redirectUrl = app.Urls.articleAddUrl;

        const categoryAddModelView = {
            Name: $("input[id=categoryName]").val()
        }

        const jsonData = JSON.stringify(categoryAddModelView);
        console.log(jsonData);

        $.ajax({
            url: addUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () {
                    window.location.href = redirectUrl
                }, 1500);
            },
            error: function () {
                toast.error("bir hata oluştu", "Hata")
            }
        })
    });
})
