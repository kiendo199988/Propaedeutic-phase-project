<?php
if (!isset($_SESSION)) {
    session_start();
}
$error = null;

if (isset($_POST['submit'])) {
    //Connect to database
    $mysqli = new MySQLi('studmysql01.fhict.local', 'dbi413156', 'dbi413156', 'dbi413156');

    //Get form data
    $e = $_POST['email'];
    $p = $_POST['psw'];

    //Query
    $resultSet = $mysqli->query("Select * From account
                               Where email = '$e' and password = '$p' ");

    if ($resultSet->num_rows != 0) {
        //Proccess Login
        $row = $resultSet->fetch_assoc();

        $fName = $row["first_name"];
        $lName = $row["last_name"];
        $hasticket = $row["has_ticket"];
        $accountID = $row["Id"];
        $role = $row["role"];
        $e = $row["email"];
        $p = $row["password"];

        if ($role == 0) {
            if ($hasticket != "0") {
                $_SESSION['isBuy'] = true;
            } else {
                $_SESSION['isBuy'] = false;
            }
            $_SESSION['isLog'] = true;
            $_SESSION['user'] = true;
            $_SESSION['id']= $accountID;
            $_SESSION['firstName']= $fName;
            $_SESSION['lastName']= $lName;
            $_SESSION['email']= $e;
            header('location:userAccount.php');
        } else {
            $_SESSION['isLog'] = true;
            $_SESSION['admin'] = true;
            $_SESSION['firstName']= $fName;
            $_SESSION['id']= $accountID;
            header('location:adminAccount.php');
        }
    } else {
        //Invalid
        $error = "<p> The email or password you entered is incorrect!</p>";
    }
}
?>
<!DOCTYPE html>
<html lang="en">

<head>
    <?php
    include("template/head.php")
    ?>
    <title>Login</title>
</head>

<body>
<section class="header">
    <?php
    include("template/menu_pages.php")
    ?>
    <div class="head-line">
        <h1>Login </h1>
    </div>
</section>
<div class="fes-info">
    <i class="fa fa-calendar" style="font-size:24px"> Event date: 24-26 January 2020</i>
    <i class="fa fa-map-marker" style="font-size:24px"> Event location : Wezuperbrug, Molecaten Park Kuierpad</i>
</div>
<br>
<div class="loginTitle">
    <h4 class="loginTitle">Please fill in your account information.</h4>
</div>
<br />
<div class="reg">
  <form class="register" action="" method="post">
    <div>
      <label>Email</label>
      <input type="text" placeholder="Enter Email" name="email" required>
    </div>
    <div>
      <label>Password</label>
      <input type="password" placeholder="Enter Password" name="psw" required>
    </div>
    <div>
      <input type="checkbox" checked="checked" name="remember" >
      <label for="remember"> Remember me </label>
    </div>
    <div>
        <button type="submit" name="submit" class="signupbtn">Log in</button>
    </div>
    <div>
      <p>Do not have an account? <a href="signUp.php">Sign up now!</a></p>
    </div>
    <?php
    if ($error != null) {
        echo $error;
    }
    $error = null;
    ?>
  </form>
</div>
<br><br><br><br>


<?php
include("template/footer.php")
?>

</body>
</html>
