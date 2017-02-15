function AddUser() {

    var username = $("#txtusername").val();
    var password = $("#txtpassword").val();
    var truename = $("#txttruename").val();
    //var role = $("#ddlrole  option:selected").val();
    var role = 1;
    alert(role);
    //if (username="")
    //{
    //    alert("请输入用户名！");
    //}
    //if (truename="") {
    //    alert("请输入真实姓名！");
    //}
    $.ajax({
        type: "POST",
        url: "User/AddUser",
        data: {
            username: txtusername,
            password: txtpassword,
            truename: txttruename,
            role: role
        },
        success: function (msg) {
            alert("操作成功");
            window.location = location;
        }
    });

}