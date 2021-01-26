<?php
session_start();
session_destroy();
$_SESSION['isLog'] = false;

header('location:index.php')
 ?>
