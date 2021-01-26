<?php
if (!isset($_SESSION)) {
    session_start();
}
$error = null;
if (isset($_POST['submit'])) {
    //Get form data
    $fName = $_POST['first_name'];
    $lName = $_POST['last_name'];
    $dob = $_POST['dob'];
    $email = $_POST['email'];
    $phone = $_POST['phone_number'];
    $address = $_POST['address'];
    $pass = $_POST['psw'];
    $pass2 = $_POST['psw-repeat'];

    //if two passwords are identical
    if ($pass2 != $pass) {
        $error = "<p>Your passwords are not match!</p>";
    } else {
        //Form is valid
        //Connect to database
        $mysqli = new MySQLi('studmysql01.fhict.local', 'dbi413156', 'dbi413156', 'dbi413156');
        //Insert to database
        $insert = $mysqli->query("INSERT INTO account(`first_name`, `last_name`, `email`, `password`, `dob`, `phone`, `address`)
                                        VALUES('$fName','$lName','$email','$pass','$dob', '$phone', '$address')");
        // if insert done login automatically and set session to login and role to user
        if ($insert) {
            $resultSet = $mysqli->query("Select * From account
                           Where email = '$email' and password = '$pass' ");

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
                $_SESSION['pass'] = $p;
            }
            header('location:tickets1.php');
        } else {
            echo $mysqli->error;
        }
    }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <?php
    include("template/head.php")
    ?>
    <title>Sign up</title>
</head>

<body>

<div class="header">
    <?php
    include("template/menu_pages.php")
    ?>
    <div class="head-line">
        <h1>Sign Up</h1>
    </div>
</div>
<div class="fes-info">
    <i class="fa fa-calendar" style="font-size:24px"> Event date: 24-26 January 2020</i>
    <i class="fa fa-map-marker" style="font-size:24px"> Event location : Wezuperbrug, Molecaten Park Kuierpad</i>
</div>
<br>
<div class="signupTitle">
    <h4>Please sign up first to be able to buy tickets</h4>
    <h4>Already have an account? <a href="logIn.php">login here!</a></h4>
</div>
<br />
<div class="reg">
  <form class="register" action="" method="post">
    <div>
      <label>* First Name</label>
      <input type="text" placeholder="" name="first_name" required>
    </div>
    <div>
      <label>* Last Name</label>
      <input type="text" placeholder="" name="last_name" required>
    </div>
    <div>
      <label>* Date of birth</label>
      <input type="date" name="dob" value="2018-07-22" min="1960-01-01" max="2018-12-31">
    </div>
    <div>
      <label>* Email</label>
      <input type="text" placeholder="" name="email" required>
    </div>
    <div>
      <label>* Phone number</label>
      <input type="text" placeholder="06 13245678" name="phone_number" pattern="[0-9]{2}[0-9]{8}" required>
    </div>
    <div>
      <label>* Address</label>
      <input type="text" placeholder="Ex: Rachelsmolen 1, 5612 MA Eindhoven" name="address" required>
    </div>
    <div>
      <label>* Password</label>
      <input type="password" placeholder="Enter Password" name="psw" required>
    </div>
    <div>
      <label>* Repeat Password</label>
      <input type="password" placeholder="Repeat Password" name="psw-repeat" required>
    </div>
    <div>
      <input type="checkbox" checked="checked" name="agree" class="emailPassRepeat">
      <label for="agree">By creating an account you agree to our <a href="https://policies.google.com/privacy">Terms & Privacy</a></label>
    </div>
    <div>
      <button type="submit" name="submit" class="signupbtn" required>Sign Up</button>
    </div>

    <?php
    if ($error != null) {
        echo $error;
    }
    $error = null;
    ?>
  </form>
</div>
<br><br><br>

<?php
include("template/footer.php")
?>
</body>
