<?php
if (!isset($_SESSION)) {
    session_start();
}
$dbhost = "studmysql01.fhict.local";
$dbuser = "dbi413156";
$dbpass = "dbi413156";
$db = "dbi413156";
$conn = new mysqli($dbhost, $dbuser, $dbpass, $db) or die("Connect failed: %s\n" . $conn->error);

function runSQL($sql, $conn)
{
    if ($conn->query($sql) === TRUE) {
        $insert_sql = $conn->insert_sql;
        return true;
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
        return false;
    }
}
?>
