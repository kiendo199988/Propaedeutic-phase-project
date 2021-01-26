<?php
if (!isset($_SESSION)) {
    session_start();
}

?>
<!DOCTYPE html>
<html lang="en">

<head>
    <?php
    include("template/head.php");
    include 'charts.php';
    ?>
    <title>Account</title>
</head>

<body>
<section class="header">
    <?php
    include("template/menu_pages.php")
    ?>
    <div class="head-line">
        <?php
        echo "<h1 class=\"success\">Welcome ".$_SESSION['firstName']."</h1>";
        ?>
    </div>
</section>
<div class="fes-info">
    <i class="fa fa-calendar" style="font-size:24px"> Event date: 24-26 January 2020</i>
    <i class="fa fa-map-marker" style="font-size:24px"> Event location : Wezuperbrug, Molecaten Park Kuierpad</i>
</div>

<div class="stats-container">

    <center><h2>Control panel</h2></center>
    <div class="tabs">
      <button class="tablink" onclick="openPage('AllVisitors', this, '#2196F3')" id="defaultOpen">All Visitors</button>
      <button class="tablink" onclick="openPage('VisitorsStatistics', this, '#2196F3')" >Visitors Statistics</button>
      <button class="tablink" onclick="openPage('ShopsStatistics', this, '#2196F3')">Shops Statistics</button>
      <button class="tablink" onclick="openPage('VisitorHistory', this, '#2196F3')">Visitor History</button>

      <div id="AllVisitors" class="tabcontent" >
        <?php
        $conn = new mysqli('studmysql01.fhict.local', 'dbi413156', 'dbi413156', 'dbi413156') or die("Connect failed: %s\n" . $conn->error);
        $sql = "SELECT Id, first_name, last_name, email, dob, balance, phone, address, CASE has_ticket WHEN 1 THEN 'yes' ELSE 'no' END AS has_ticket,
                CASE checked_event WHEN 1 THEN 'yes' ELSE 'no' END AS checked_event, CASE has_cs WHEN 1 THEN 'yes' ELSE 'no' END AS has_cs,
                CASE checked_cs WHEN 1 THEN 'yes' ELSE 'no' END AS checked_cs, CASE role WHEN 1 THEN 'Admin' ELSE 'User' END AS role FROM account ;";
        $result = mysqli_query($conn, $sql) or die("bad query: $sql");
        echo '<table border="2">';
        echo '<tr><td>ID Number</td><td>Full Name</td><td>Email</td><td>Date of birth</td>
          <td>Balance</td><td>Phone Number</td><td>Address</td><td>Has Ticket</td><td>Checked In</td><td>Has Camping Spot</td><td>checked_cs</td><td>Role</td></tr>';
        while ($row = mysqli_fetch_assoc($result)) {
            echo "<tr><td>{$row['Id']}</td><td>{$row['first_name']} {$row['last_name']}</td><td>{$row['email']}</td><td>{$row['dob']}</td>
              <td>{$row['balance']}</td><td>{$row['phone']}</td><td>{$row['address']}</td><td>{$row['has_ticket']}</td><td>{$row['checked_event']}</td>
              <td>{$row['has_cs']}</td><td>{$row['checked_cs']}</td><td>{$row['role']}</td></tr>";
        }
        echo'</table>';
        ?>
      </div>
      <div id="VisitorsStatistics" class="tabcontent">
        <div class="charts">
          <div id="chartContainer1" style="position: relative; width: 600px; height: 400px;"></div>
          <div id="chartContainer2" style="position: relative; width: 600px; height: 400px;"></div>
          <div id="chartContainer3" style="position: relative; width: 600px; height: 400px;"></div>
        </div>
        <div class="charts">
          <div id="chartContainer4" style="position: relative; width: 600px; height: 400px;margin-top: 2rem;"></div>
          <div id="chartContainer7" style="position: relative; width: 600px; height: 400px;margin-top: 2rem;"></div>
        </div>
          <!-- <div id="columnchart_values2"></div>
          <div id="columnchart_values3"></div> -->

      </div>
      <div id="ShopsStatistics" class="tabcontent">
        <div class="charts">
          <div id="chartContainer5" style="position: relative; width: 600px; height: 400px;"></div>
          <div id="chartContainer6" style="position: relative; width: 600px; height: 400px;"></div>
          <div id="chartContainer8" style="position: relative; width: 600px; height: 400px;"></div>
        </div>
        <div class="charts">
          <div id="chartContainer9" style="height: 400px; width: 100%; margin-top: 2rem;"></div>
      </div>
      <div id="VisitorHistory" class="tabcontent"></div>
    </div>
</div>
<?php
include("template/footer.php")
?>
<script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
<script src="javascript.js" charset="utf-8"></script>
</body>
</html>
