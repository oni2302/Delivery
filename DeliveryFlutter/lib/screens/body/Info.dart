import 'package:delivery/screens/LoginScreen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_session_manager/flutter_session_manager.dart';

class Info extends StatelessWidget {
  const Info({super.key});
  @override
  Widget build(BuildContext context) {
    return Column(mainAxisAlignment: MainAxisAlignment.center, children: [
      ElevatedButton(
        child: const Text("Đăng xuất"),
        onPressed: () {
          SessionManager().destroy();
          Navigator.of(context).pushReplacement(MaterialPageRoute(
            builder: (context) => LoginScreen(),
          ));
        },
      ),
    ]);
  }
}
