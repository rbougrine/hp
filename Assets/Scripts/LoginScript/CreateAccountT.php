<?php

$Name = $_REQUEST["Name"];
$Password = $_REQUEST["Password"];

$Hostname = "";
$DBName = "";
$User = "";
$PasswordP ="";

mysql_connect($hostname, $User, $PasswordP);
mysql_select_db($DBName) or die("Can't Connect to DB");

if(! $Name || ! $PasswordP)
{
	echo "Empty";
}else
{
	$sql = "SELECT * FROM Accounts WHERE Name = '". $Name ."'";
	$Result  = @mysql_query($sql) or die ("DB Error");
	$Total = mysql_num_rows($Result);

	if ($Total == 0)
	{
		$insert = "INSERT INTO 'Accounts' ('Name','Password') VALUES ('".$Name."',MD5('".$Password."'))";
		$SQL1 = mysql_query($insert);
		echo "Success";
	}else 
	{
		echo "AlreadyUsed";
	
	}
}


?>