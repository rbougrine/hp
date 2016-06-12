<?php

require 'rb.php';

$hostname = "localhost";
$DBName = "unity";
$user = "root";
$PasswordDB = "";
$key = md5("Rotterdam");

    R::setup('mysql:host='. $hostname .';dbname='. $DBName, $user, $PasswordDB);
    $isConnected = R::testConnection();
    if (!$isConnected)
    {
        echo "not connected";
    }
     else
        {
       // echo "Succesfully connected with".$DBName;
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
