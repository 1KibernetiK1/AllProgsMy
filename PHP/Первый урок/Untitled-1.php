<?php 

$user = [

[
    'name' => 'Саша',
    'age' => 8,
],
[
    'name' => 'Таня',
    'age' => 6,
],
[
    'name' => 'Миша',
    'age' => 12,
],
[
    'name' => 'Вася',
    'age' => 9,
],

];

$names = array_column($user, "name")
echo '/pre';
print_r($names);
echo '/pre';
?>
