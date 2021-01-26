<?php
?>
<nav class="navbar navbar-expand-sm">

    <ul class="navbar-nav">
        <li class="nav-item">
            <a class="nav-link pp" href="index.php">Home</a>
        </li>
        <?php
        if (isset($_SESSION['isLog'])){
            echo '<li class="nav-item">
            <a class="nav-link pp" href="tickets1.php">Tickets</a>
        </li>';
        }else{
            echo '<li class="nav-item">
            <a class="nav-link pp" href="signUp.php">Tickets</a>
        </li>';
        }
        ?>
        <li class="nav-item">
            <a class="nav-link pp" href="reviews.php">Reviews</a>
        </li>
        <?php
        if (isset($_SESSION['isLog'])) {
            if(isset($_SESSION['user'])){
                echo '<li class="nav-item">
                    <a class="nav-link pp" href="userAccount.php">'.$_SESSION['firstName'].'</a>
                   </li>';
            }
            else{
                echo '<li class="nav-item">
                    <a class="nav-link pp" href="adminAccount.php">'.$_SESSION['firstName'].'</a>
                   </li>';
            }
            echo '<li class="nav-item">
                    <a class="nav-link pp" href="logOut.php">LogOut</a>
                   </li>';
        } else {
            echo '<li class="nav-item">
                    <a class="nav-link pp" href="signUp.php">SignUp</a>
                   </li>';
            echo '<li class="nav-item">
                    <a class="nav-link pp" href="logIn.php">LogIn</a>
                  </li>';
        }
        ?>
    </ul>

</nav>
<div class="logo-se">
    <a href="index.php">
        <img src="img/mflogo.png" alt="mf logo">
    </a>
</div>
