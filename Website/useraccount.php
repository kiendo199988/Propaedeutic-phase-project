
<?php
if (!isset($_SESSION)) {
    session_start();
}
$error = null;
if (isset($_POST['submit'])) {
    //Get form data
    $id=$_SESSION['id'];
    $amount = $_POST['money'];
    $mysqli = new MySQLi('studmysql01.fhict.local', 'dbi413156', 'dbi413156', 'dbi413156');
    $insert = $mysqli->query("UPDATE account SET balance = balance + '$amount' WHERE id='$id'");
    $insert2 = $mysqli->query("UPDATE balance SET total_deposit = total_deposit + '$amount'");
}
?>
<!DOCTYPE html>
<html lang="en">

<head>
    <?php
    include("template/head.php")
    ?>
    <title>Account</title>
</head>

<body>

<div class="header">
    <?php
    include("template/menu_pages.php")
    ?>
    <div class="head-line">
      <?php
        echo '<h1 style="color:#666633;"><b>Welcome '.$_SESSION['firstName'].'</b></h1>';
      ?>
    </div>
</div>
<div class="fes-info">
    <i class="fa fa-calendar" style="font-size:24px"> Event date: 24-26 January 2020</i>
    <i class="fa fa-map-marker" style="font-size:24px"> Event location : Wezuperbrug, Molecaten Park Kuierpad</i>
</div>
<br /><br />
<div class="tickets-container">
  <table class="table table-striped">
    <tbody style="text-align:center;">
      <?php
        $mysqli = new mysqli('studmysql01.fhict.local', 'dbi413156', 'dbi413156', 'dbi413156') or die("Connect failed: %s\n" . $conn->error);
        $id=$_SESSION['id'];
        $resultSet = $mysqli->query("SELECT Id, first_name, last_name, email, CONCAT('€ ', FORMAT(balance, 2)) AS balance ,CASE has_cs WHEN 1 THEN 'yes' ELSE 'no' END AS has_cs FROM account where Id = '$id'");
        $row = $resultSet->fetch_assoc();
          echo"<tr>
              <td style=\"font-size:19px; color:#4CAF50;\"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Personal Info</b></td>
            </tr>
            <tr>
              <td style=\"font-size:19px\"><i>ID: ".$row["Id"]."</i></td>
            </tr>
            <tr>
              <td style=\"font-size:19px\"><i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;First name: ".$row["first_name"]."</i></td>
            </tr>
            <tr>
              <td style=\"font-size:19px\"><i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Last name: ".$row["last_name"]."</i></td>
            </tr>
            <tr>
              <td style=\"font-size:19px\"><i>&nbsp;&nbsp;&nbsp;&nbsp;Email: ".$row["email"]."</i></td>
            </tr>
            <tr>
              <td style=\"font-size:19px\"><i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Camping spot: ".$row["has_cs"]."</i></td>
            </tr>
            <tr>
              <td style=\"font-size:19px\"><i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Balance: ".$row["balance"]."</i></td>
            </tr>
            ";

      ?>
      </tbody>
  </table>
</div>
<br>

    <form class="register" action="" method="post">
          <label style="font-size:24px">Deposite money</label>
          <input type="text" placeholder="Amount of money Ex: 20.30" name="money" required><br>
          <div>
            <button type="submit" name="submit" class="btn-prev" required>Deposite</button>
          </div>
    </div>
    <?php
    if ($error != null) {
        echo $error;
    }
    $error = null;
    ?>
    </form>

    <div class="down-home">
        <a href="PDF.php" download='MyWinterFestTicket' type="btn" class="btn-download">Download your ticket</a>

        <a type="btn" href="index.php" class="btn-home">Go to home</a>
    </div>
    </div>
</div>

<?php
include("template/footer.php")
?>
</body>
