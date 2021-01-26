<?php
if (!isset($_SESSION)) {
    session_start();
}

?>
<!DOCTYPE html>
<html lang="en">

<head>
    <?php
    include("template/head.php")
    ?>
    <title>Tickets</title>
</head>

<body>

<div class="header">
    <?php
    include("template/menu_pages.php")
    ?>
    <div class="head-line">
    <h1>Book your tickets now ! </h1>
    </div>
</div>
<div class="fes-info">
    <i class="fa fa-calendar" style="font-size:24px"> Event date: 24-26 January 2020</i>
    <i class="fa fa-map-marker" style="font-size:24px"> Event location : Wezuperbrug, Molecaten Park Kuierpad</i>
</div>
<br /><br /><br />
<div class="header">
<div class="head-line">
    <h2>Your ticket(s) have been successfully reserved !</h2>
    <?php
    echo '<h2>Confirmation email has been sent to '.$_SESSION['email'].' !</h2>'
    ?>
    <br>
</div>
</div>
<br /><br /><br /><br />
<div class="my">
<a type="btn" href="userAccount.php" class="my-account">My account</a>
</div>
<br /><br /><br /><br />
<?php
include("template/footer.php")
?>
</body>
