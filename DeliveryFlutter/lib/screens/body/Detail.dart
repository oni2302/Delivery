import 'package:delivery/Entities/DonHang.dart';
import 'package:flutter/material.dart';
import 'package:vertical_stepper/vertical_stepper.dart';
import 'package:vertical_stepper/vertical_stepper.dart' as step;

class Detail extends StatefulWidget {
  static DonHang? donHang;
  const Detail({super.key});

  @override
  State<Detail> createState() => _DetailState();
}

class _DetailState extends State<Detail> with TickerProviderStateMixin {
  List<step.Step> steps = [
    const step.Step(
        shimmer: false,
        title: "Nhận hàng về kho",
        iconStyle: Colors.green,
        content: Align(
          alignment: Alignment.centerLeft,
          child: Text("12:30:40 02/05/2023"),
        )),
    const step.Step(
        shimmer: false,
        title: "Phân phối cho nhân viên giao hàng",
        iconStyle: Colors.green,
        content: Align(
          alignment: Alignment.centerLeft,
          child: Text("12:30:40 02/05/2023"),
        )),
    const step.Step(
        shimmer: false,
        title: "Nhân viên đã lấy hàng",
        iconStyle: Colors.green,
        content: Align(
          alignment: Alignment.centerLeft,
          child: Text("12:30:40 02/05/2023"),
        )),
    const step.Step(
        shimmer: false,
        title: "Nhân viên đang giao",
        iconStyle: Colors.green,
        content: Align(
          alignment: Alignment.centerLeft,
          child: Text("12:30:40 02/05/2023"),
        )),
    const step.Step(
        shimmer: false,
        title: "Nhân viên đã giao",
        iconStyle: Colors.red,
        content: Align(
          alignment: Alignment.centerLeft,
          child: Text("12:30:40 02/05/2023"),
        )),
  ];

  @override
  Widget build(BuildContext context) {
    if (Detail.donHang != null) {
      return SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            Card(
              margin: const EdgeInsets.only(bottom: 5, left: 20, right: 20),
              child: Container(
                padding: const EdgeInsets.all(10),
                width: double.infinity,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Mã đơn hàng: ${Detail.donHang!.maDonHang}',
                      style: const TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Colors.green,
                      ),
                    ),
                    Text(
                      'Trạng thái: ${Detail.donHang!.tenTrangThai}',
                      style: const TextStyle(
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ],
                ),
              ),
            ),
            Card(
              margin: const EdgeInsets.only(bottom: 5, left: 20, right: 20),
              child: Container(
                padding: const EdgeInsets.all(10),
                width: double.infinity,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Từ: ${Detail.donHang!.nguoiGui}',
                      style: const TextStyle(
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    Text(
                      'Địa chỉ: ${Detail.donHang!.tu}',
                    ),
                    Text(
                      'Số điện thoại: ${Detail.donHang!.sdtNguoiGui}',
                    ),
                  ],
                ),
              ),
            ),
            Card(
              margin: const EdgeInsets.only(bottom: 5, left: 20, right: 20),
              child: Container(
                padding: const EdgeInsets.all(10),
                width: double.infinity,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Đến: ${Detail.donHang!.nguoiNhan}',
                      style: const TextStyle(
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    Text(
                      'Địa chỉ: ${Detail.donHang!.diaChiNguoiNhan}, ${Detail.donHang!.diaChiPhuong}, ${Detail.donHang!.diaChiQuan}, ${Detail.donHang!.diaChiThanhPho}',
                    ),
                    Text(
                      'Số điện thoại: ${Detail.donHang!.sdtNguoiNhan}',
                    ),
                  ],
                ),
              ),
            ),
            Card(
              margin: const EdgeInsets.only(bottom: 5, left: 20, right: 20),
              child: Container(
                padding: const EdgeInsets.all(10),
                width: double.infinity,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const Text(
                      'Ghi Chú:',
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    Text('${Detail.donHang!.ghiChu}')
                  ],
                ),
              ),
            ),
            const Padding(
              padding: EdgeInsets.only(
                left: 20,
                bottom: 4,
                top: 8,
              ),
              child: Text(
                "Trạng thái",
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.green,
                ),
              ),
            ),
            VerticalStepper(
              steps: steps,
              dashLength: 2,
            )
          ],
        ),
      );
    } else {
      return const Center(
        child: Text("Rỗng"),
      );
    }
  }
}
