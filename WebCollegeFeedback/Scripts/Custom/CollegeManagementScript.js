var oTblCollegeList = "";
var EditCollege = "";
$(document).ready(function () {
    // on add college button click
    $(".add-clg").click(function () {
        $(".CollegeManagementScreen").fadeOut(500);
        $(".AddCollege").fadeIn(800);
    });

    // on back to college list button click
    $(".back-clg").click(function () {
        $(".AddCollege").fadeOut(500);
        $(".CollegeManagementScreen").fadeIn(800);
        oTblCollegeList.ajax.reload();
    });

    $.validator.addMethod("wordCount", function (value, element, wordCount) {
        return value.split(' ').length <= wordCount;
    });

    var AddCollege = $("#CollegeFormAdd").validate({
        rules: {
            "clgName": {
                required: true,
                minlength: 5
            },
            "address": {
                required: true,
                minlength: 5
            },
            "clgLink": {
                required: true,
                minlength: 10
            },
            "aboutClg": {
                required: true,
                wordCount: 100
            },
            "clgImg": {
                required: true,
                extension: "jpg|jpeg|png|JPG|JPEG|PNG"
            }
        },
        messages: {
            "clgName": {
                required: "Please, enter College name"
            },
            "address": {
                required: "Please, enter address"
            },
            "clgLink": {
                required: "Please, enter college URL link"
            },
            "aboutClg": {
                required: "Please, write about the college details",
                wordCount: "Please, write about the college in maximum 100 words only"
            },
            "clgImg": {
                required: "Please, upload the college photo.",
                extension: "Please, upload image only with format .JPG / .PNG"
            }
        },
        submitHandler: function (form) { // for demo
            //alert('valid form submitted'); // for demo
            //debugger;
            // Checking whether FormData is available in browser  
            if (window.FormData !== undefined) {

                var fileUpload = $("#txtImage").get(0);
                var files = fileUpload.files;

                if (files.length > 1) {
                    alert("Please select one file only");
                    return false;
                }

                if (!ValidateSize(files)) {
                    alert('File size exceeds 2 MB');
                    return false;
                }

                // Create FormData object  
                var fileData = new FormData();

                // Looping over all files and add it to FormData object  
                for (var i = 0; i < files.length; i++) {
                    fileData.append(files[i].name, files[i]);
                }


                // Adding one more key to FormData object  
                fileData.append('CollegeName', $("#txtclgName").val());
                fileData.append('Link', $("#txtclgLink").val());
                fileData.append('Address', $("#txtaddress").val());
                fileData.append('Image', $("#txtImage").val());
                fileData.append('AboutCollege', $("#txtaboutClg").val());

                //Common.Ajax("POST", '/Colleges/AddCollegeDetails', fileData, 'json', function () {
                //    alert(result);
                //}, false, false);


                $.ajax({
                    url: '../CollegeManagement/AddCollegeDetails',
                    type: "POST",
                    contentType: false, // Not to set any content header  
                    processData: false, // Not to process data  
                    data: fileData,
                    success: function (result) {
                        swal("Gotcha!", result, "success");
                        $("#btnCollegeReset").click();
                    },
                    error: function (err) {
                        alert(err.statusText);
                    }
                });
            } else {
                alert("FormData is not supported.");
            }
            return false; // for demo
        }
    });

    $("#btnCollegeReset, .back-clg").click(function () {
        AddCollege.resetForm();
    });


    EditCollege = $("#CollegeDetailFormEdit").validate({
        rules: {
            "txtCollegeName": {
                required: true,
                minlength: 5
            },
            "txtClgAddress": {
                required: true,
                minlength: 5
            },
            "txtClgLink": {
                required: true,
                minlength: 10
            },
            "txtClgAbout": {
                required: true,
                wordCount: 100
            },
            "clgImg": {
                required: true,
                extension: "jpg|jpeg|png|JPG|JPEG|PNG"
            }
        },
        messages: {
            "txtCollegeName": {
                required: "Please, enter College name"
            },
            "txtClgAddress": {
                required: "Please, enter address"
            },
            "txtClgLink": {
                required: "Please, enter college URL link"
            },
            "txtClgAbout": {
                required: "Please, write about the college details",
                wordCount: "Please, write about the college in maximum 100 words only"
            },
            "clgImg": {
                required: "Please, upload the college photo.",
                extension: "Please, upload image only with format .JPG / .PNG"
            }
        },
        submitHandler: function (form) { // for demo

            var ClgFileUpload = $("#txtClgImage").get(0);
            var formObj = [
                { "key": "CollgId",      "value": $("#txtCollegeId").val() },
                { "key": "CollegeName",  "value": $("#txtCollegeName").val() },
                { "key": "Link",         "value": $("#txtClgLink").val() },
                { "key": "Address",      "value": $("#txtClgAddress").val() },
                { "key": "AboutCollege", "value": $("#txtClgAbout").val() },
            ];
            var URL = '../Colleges/UpdateCollegeDetails';

            OperateCollegeDetails(ClgFileUpload, formObj, URL, function (res) {
                if (res.Code == 200) {
                    oTblCollegeList.ajax.reload();
                    $('#myModal').modal('hide');
                    swal("Gotcha!", res.message, "success");
                }
                else {
                    oTblCollegeList.ajax.reload();
                    $('#myModal').modal('hide');
                    swal("Sorry!", res.message, "error");
                }
                
            });
            return false;
        }
    })

    bindCollegeList();

    $("#btnClgFormEdit").click(function () {
        try {
            $(".CollegeDetails").hide();
            $(".CollegeDetailsEdit").show();

            $("#btnClgFormEdit, #btnCls").hide();
            $("#btnClgFormSubmit, #btnClgFormBack").show();

        } catch (e) {
            console.log(e);
        }
    })

    $("#btnClgFormBack").click(function () {
        $(".CollegeDetails").show();
        $(".CollegeDetailsEdit").hide();

        $("#btnClgFormEdit, #btnCls").show();
        $("#btnClgFormSubmit, #btnClgFormBack").hide();
    });

})


function ValidateSize(file) {
    var FileSize = file[0].size / 1024 / 1024; // in MB
    if (FileSize > 2) {
        return false;
        // $(file).val(''); //for clearing with Jquery
    } else {
        return true;
    }
}

function bindCollegeList() {
    //try {
    oTblCollegeList = $(".tblColgList").DataTable({
        'processing': true,
        'language': {
            'loadingRecords': '&nbsp;',
            'processing': 'Loading...'
        },
        "ajax": {
            "url": 'CollegeList',
            "type": "get",
            "datatype": "json"
        },
        "columns": [
            { "data": "CollgId", "autoWidth": true },
            // { "data": "CollegeName", "autoWidth": true },
            {
                "data": "CollegeName", "render": function (data, type, row) {

                    return "<a class='popup' href='javascript:LoadCollegeData(\"" + row.CollgId + "\", \"" + row.CollegeName + "\")'><b>" + row.CollegeName + "</b></a>";
                }, "width": "180px"
            },
            {
                "data": "Link", "autoWidth": true, "render": function (data, type, row) {
                    return truncateString(row.Link, 30);
                }
            },
            {
                "data": "Address", "autoWidth": true, "render": function (data, type, row) {
                    return truncateString(row.Address, 30);
                }
            },
            {
                "data": "AboutCollege", "autoWidth": true, "render": function (data, type, row) {
                    return truncateString(row.AboutCollege, 30);
                }
            },
            {
                "data": "CollgId", "width": "50px", "className":"dt-body-center", "render": function (data) {
                    return "<a class='popup text-danger' href='javascript:DeActivateCollege(\"" + data + "\")'><i class='fa fa-2x fa-times'></i></a>";
                }
            },
        ]

    });
    //} catch (e) {
    //    console.log(e);
    //}  href="/Colleges/FindCollege/' + data + '/College"
}

function LoadCollegeData(CollegeId, CollegeName) {

    $(".CollegeDetailsEdit").hide();
    $(".CollegeDetails").show();

    $("#btnClgFormEdit, #btnCls").show();
    $("#btnClgFormSubmit, #btnClgFormBack").hide();
    

    $(".clgTitle").html(CollegeName);

    Common.Ajax("GET", "FindCollege/" + CollegeId + "/College", null, "JSON", function (res) {        
        var ClgData = res.data;
        $("#imgCollegeImage").attr("src", ClgData.Image.replace("//Uploads//CollegeImages//", '/Uploads/CollegeImages/'));        
        $("#collegeId, #txtCollegeId").val(ClgData.CollgId);
        $("#collegeName, #txtCollegeName").val(ClgData.CollegeName);
        $("#collegeLink, #txtClgLink").val(ClgData.Link);
        $("#collegeAbout, #txtClgAbout").text(ClgData.AboutCollege);
        $("#CollegeAddress, #txtClgAddress").text(ClgData.Address);

        $('#myModal').modal('show');

        EditCollege.resetForm();
    }, false, false);
}

function DeActivateCollege(CollegeId) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, it will be removed from our database forever!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {

                $.ajax({
                    url: '../CollegeManagement/DeleteCollegeDetails',
                    type: "POST",
                    contentType: "application/json;charset=utf-8", // Not to set any content header  
                    processData: false, // Not to process data  
                    data: JSON.stringify({
                        CollegeId: CollegeId
                    }),
                    success: function (res) {
                        if (res.Code == 200) {
                            oTblCollegeList.ajax.reload();
                            swal("Poof! College details are deleted!", {
                                icon: "success",
                            });
                        }
                        else {
                            swal("Sorry!", res.message, "error");
                        }
                    },
                    error: function (err) {
                        alert(err.statusText);
                    }
                });
            } else {
                swal("Your college details are safe for now!");
            }
        });
}

function OperateCollegeDetails(ClgFileUpload, formObj, URL, ResFunction) {
    if (window.FormData !== undefined) {

        var fileUpload = ClgFileUpload; // $("#txtImage").get(0);
        var files = fileUpload.files;

        if (files.length > 1) {
            alert("Please select one file only");
            return false;
        }

        if (!ValidateSize(files)) {
            alert('File size exceeds 2 MB');
            return false;
        }

        // Create FormData object  
        var fileData = new FormData();

        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }

        for (var i in formObj) {
            fileData.append(formObj[i]["key"], formObj[i]["value"]);
        }

        $.ajax({
            url: '../CollegeManagement/UpdateCollegeDetails',
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: ResFunction,
            error: function (err) {
                alert(err.statusText);
            }
        });
    } else {
        alert("FormData is not supported.");
    }
}


function truncateString(str, num) {
    // If the length of str is less than or equal to num
    // just return str--don't truncate it.
    if (str.length <= num) {
        return str
    }
    // Return str truncated with '...' concatenated to the end of str.
    return str.slice(0, num) + '...'
}