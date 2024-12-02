<?php
if (!isset($_GET['key'])) {
    http_response_code(403);
    exit();
}

$pwd = $_GET['key']; 

if ($pwd !== 'q69if47g1v') {
    http_response_code(403);
    exit();
}

$json = "players.json";

$url = "https://api-mna.runasp.net/lobby/players?key=f7g9q14i6v";

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