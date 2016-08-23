<?php

$hostname = "localhost";
$DBName = "unity";
$user = "root";
$PasswordDB ="";
$key = md5("Rotterdam");
try {

    $dbh = new PDO('mysql:host='. $hostname .';dbname='. $DBName, $user, $PasswordDB);
   // echo "Database connection is successful  ";
}
catch(PDOException $e)
{
    echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage(), '</pre>';
}

function encrypt ($string,$key)
{
    $string = rtrim(base64_encode(mcrypt_encrypt(MCRYPT_RIJNDAEL_256,$key,$string,MCRYPT_MODE_ECB)));
    return $string;
}
function decrypt ($string,$key)
{
    $string = rtrim(mcrypt_decrypt(MCRYPT_RIJNDAEL_256,$key, base64_decode($string),MCRYPT_MODE_ECB));
    return $string;
}