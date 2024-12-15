// Tạo phiếu gia hạn 
function taoPhieu() {
    var ph = document.getElementById("taoPhieu");
    const modal = document.querySelector("#formModal");
    const modalInstance = bootstrap.Modal.getInstance(modal);

    let maphieumuon = document.getElementById("maphieumuon").value;
    let lydo = document.getElementById("lydo").value;
    let textma = document.getElementById("textma");

    if (maphieumuon == "") {
        textma.innerHTML = "Vui lòng nhập mã phiếu mượn";
        return;
    }

    let data = { Maphieu: maphieumuon, Ghichu: lydo }
    const xhttp = new XMLHttpRequest();

    xhttp.onload = function () {
        switch (JSON.parse(xhttp.responseText))
        {
            case true:
                alert("Yêu cầu gia hạn đã được gửi! Vui lòng chờ phê duyệt của Admin");
                break;
            case "toida":
                alert("Gia hạn không thành công: Phiếu mượn đạt số lần gia hạn tối đa");
                break;
            case "khongco": 
                alert("Gia hạn không thành công: Mã phiếu không đúng");
                break;
            case "chuaduyet": 
                alert("Gia hạn không thành công: Phiếu mượn chưa được duyệt");
                break;
            case "tuchoi": 
                alert("Gia hạn không thành công: Phiếu mượn đã bị từ chối");
                break;
            case "chogiahan": 
                alert("Gia hạn không thành công: Phiếu mượn đang có yêu cầu gia hạn chưa duyệt");
                break;
        }
        location.href = "/Docgia/dsPhieugiahan";
    }

    modalInstance.hide();

    const url = "/Docgia/themPhieugiahan";
    xhttp.open("POST", url);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(data));
}

// Scroll Button (Sach moi)
function scrollBack() {
    document.getElementById("bookContainer").scrollBy({ left: -300, behavior: "smooth" });
}

function scrollRight() {
    document.getElementById("bookContainer").scrollBy({ left: 300, behavior: "smooth" });
}

// Ask before closing application/web page
//window.addEventListener('beforeunload', function (e) {
//    this.confirm('Cảnh báo: Phiếu mượn đang lập sẽ không được lưu lại. Bạn chắc chắn muốn thoát?');
//    if ('@(Session["dangLapPhieu"] != null ? Session["dangLapPhieu"].ToString() : "False")' == 'True') {
//        var close = this.confirm('Cảnh báo: Phiếu mượn đang lập sẽ không được lưu lại. Bạn chắc chắn muốn thoát?');
//        if (close == 'True') {
//            const xhttp = new XMLHttpRequest();
//            const url = "/Docgia/huyPhieu";
//            xhttp.open("GET", url);
//            xhttp.send();
//        }
//    }
//})
