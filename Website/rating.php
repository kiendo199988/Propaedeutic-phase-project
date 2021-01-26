<?php
if(isset($_POST)){
	$conn = mysqli_connect('studmysql01.fhict.local', 'dbi413156', 'dbi413156', 'dbi413156');
	if(mysqli_query($conn,"INSERT INTO reviews (`name`, `rating`, `text`) VALUES('".$_POST['v1']."','".$_POST['v3']."','".$_POST['v2']."')"))
  {
		echo "1";
	}else{
		echo "2";
	}
}
?>
