$(document).ready(function () {
    $(".add-clg").click(function () {
        $(".CollegeManagementScreen").fadeOut(500);
        $(".AddCollege").fadeIn(800);
    });

    $(".back-clg").click(function () {
        $(".AddCollege").fadeOut(500);
        $(".CollegeManagementScreen").fadeIn(800);
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