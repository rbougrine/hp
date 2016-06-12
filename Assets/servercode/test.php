<?php

class Test
{
    function check()
    {
        require 'database.php';
        $code = "scene";

      //  R::exec("insert into `accounts` (username,password) values (:username,:password),[':username' => 'test102'],[':password' => '']");
      //  R::exec('insert into `accounts` (username,password) values (:username,:password)',
       //     array(':username' => 'test102', ':password' => 1));
      //  $stmt = R::findOne('accounts', ' username = ? ',array($Username));

     $entries =   R::getAll('SELECT x,y,z FROM game WHERE username = :username',
            array(':username' => 'test101')
        );

foreach ($entries as $entry)
    echo $entry['x'] . " " . $entry['y'] .  $entry['z'] ;


}








}





















?>