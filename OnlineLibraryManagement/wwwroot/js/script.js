// Tạo phiếu gia hạn 
function taoPhieu() {
    var ph = document.getElementById("taoPhieu");
    const modal = document.querySelector("#formModal");
    const modalInstance = bootstrap.Modal.getInstance(modal);

    let maphieumuon = document.getElementById("maphieumuon").value;
    let lydo = document.getElementById("lydo").value;

    let data = { Maphieu: maphieumuon, Ghichu: lydo }
    const xhttp = new XMLHttpRequest();

    xhttp.onload = function () {
        if (JSON.parse(xhttp.responseText) == true) {
            alert("Yêu cầu gia hạn đã được gửi! Vui lòng chờ phê duyệt của Admin");
            location.href = "/Docgia/dsPhieugiahan";
        }
        else if (JSON.parse(xhttp.responseText) == "toida") {
            alert("Phiếu mượn đã đạt số lần gia hạn tối đa");
        }
        else if (JSON.parse(xhttp.responseText) == "khongco") {
            alert("Mã phiếu không đúng");
        }
    }

    modalInstance.hide();

    const url = "/Docgia/themPhieugiahan";
    xhttp.open("POST", url);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(data));
}