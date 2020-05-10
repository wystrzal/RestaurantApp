const connection = new signalR.HubConnectionBuilder().withUrl("/SignalServerHub").build();

connection.on("ReceiveOrder", function () {
    window.location.reload(true);
});


async function start() {
    try {
        await connection.start();
    } catch (err) {
        console.log(err);
        setTimeout(() => start(), 5000);
    }
};

connection.onclose(async () => {
    await start();
});

start();
