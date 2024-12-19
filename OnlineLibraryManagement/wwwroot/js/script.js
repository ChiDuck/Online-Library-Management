// Tạo phiếu gia hạn 
function taoPhieu() {
    const modal = document.querySelector("#formModal");
    const modalInstance = bootstrap.Modal.getInstance(modal);

    let maphieumuon = document.getElementById("maphieumuon").value;
    let lydo = document.getElementById("lydo").value;
    let textma = document.getElementById("textma");

    if (maphieumuon.trim() == "") {
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
            case "ketthuc": 
                alert("Gia hạn không thành công: Phiếu mượn đã kết thúc");
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

// Thêm tác giả
function themTacgia() {
    const modal = document.querySelector("#formModal");
    const modalInstance = bootstrap.Modal.getInstance(modal);

    let tentg = document.getElementById("tentg").value;
    let ngaysinh = document.getElementById("ngaysinh").value;
    let ngaymat = document.getElementById("ngaymat").value;
    let quoctich = document.getElementById("quoctich").value;
    if (ngaysinh == "") ngaysinh = null;
    if (ngaymat == "") ngaymat = null;
    let data = { Tentacgia: tentg, Ngaysinh: ngaysinh, Ngaymat: ngaymat, Quoctich: quoctich }
    console.log(data);
    if (tentg.trim() === "") {
        document.getElementById("validten").innerHTML = "Vui lòng nhập tên tác giả";
        return;
    }
  
    const xhttp = new XMLHttpRequest();
    xhttp.onload = function () {
        location.href = "/Tacgia/Index"
    }

    modalInstance.hide();

    const url = "/Tacgia/themTacgia";
    xhttp.open("POST", url);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(data));
}

// Thêm thể loại
function themTheloai() {
    const modal = document.querySelector("#formModal");
    const modalInstance = bootstrap.Modal.getInstance(modal);

    var id = document.getElementById("tenloai").value;
    if (id.trim() == "") {
        document.getElementById("validten").innerHTML = "Vui lòng nhập tên thể loại";
        return;
    }
  
    const xhttp = new XMLHttpRequest();
    xhttp.onload = function () {
        location.href = "/Theloai/Index"
    }

    modalInstance.hide();

    const url = "/Theloai/themTheloai/" + id;
    xhttp.open("GET", url);
    xhttp.send();
}


// Thêm nhà xuất bản
function themNxb() {
    const modal = document.querySelector("#formModal");
    const modalInstance = bootstrap.Modal.getInstance(modal);

    let tennxb = document.getElementById("tennxb").value;
    let email = document.getElementById("email").value;
    let diachi = document.getElementById("diachi").value;
    let data = { Tennxb: tennxb, Email: email, Diachi: diachi }
    console.log(data);
    if (tennxb.trim() == "") {
        document.getElementById("validten").innerHTML = "Vui lòng nhập tên nhà xuất bản";
        return;
    }

    const xhttp = new XMLHttpRequest();
    xhttp.onload = function () {
        location.href = "/Nhaxuatban/Index"
    }

    modalInstance.hide();

    const url = "/Nhaxuatban/themNhaxuatban";
    xhttp.open("POST", url);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(data));
}