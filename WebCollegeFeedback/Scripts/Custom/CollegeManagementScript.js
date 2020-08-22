$(document).ready(function () {
    $(".add-clg").click(function () {
        $(".CollegeManagementScreen").fadeOut(500);
        $(".AddCollege").fadeIn(800);
    })

    $(".back-clg").click(function () {
        $(".AddCollege").fadeOut(500);
        $(".CollegeManagementScreen").fadeIn(800);
    })
})