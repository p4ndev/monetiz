<?php
if (!isset($_GET['key'])) {
    http_response_code(403);
    exit();
}

$pwd = $_GET['key']; 

if ($pwd !== '4dw9Jc2z6p') {
    http_response_code(403);
    exit();
}

$json = "tenants.json";

$url = "https://api-mna.runasp.net/lobby/tenants?key=w2z9Jc4d6p";

$response = file_get_contents($url);

if ($response === FALSE) {
    http_response_code(400);
    exit;
}

if (file_put_contents($json, $response)) {
    http_response_code(201);
} else {
    http_response_code(400);
}

exit;
?>