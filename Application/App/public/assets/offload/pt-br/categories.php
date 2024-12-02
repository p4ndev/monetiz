<?php
if (!isset($_GET['key'])) {
    http_response_code(403);
    exit();
}

$pwd = $_GET['key']; 

if ($pwd !== 'n9u2ujp4r0') {
    http_response_code(403);
    exit();
}

$json = "categories.json";

$url = "https://api-mna.runasp.net/lobby/categories?key=jr4n0u9u2p";

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