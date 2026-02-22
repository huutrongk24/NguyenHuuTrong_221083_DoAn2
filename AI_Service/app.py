from flask import Flask, request, jsonify
import joblib
import numpy as np

app = Flask(__name__)

# Load model đã train
model = joblib.load("linear_model.pkl")

@app.route("/predict", methods=["POST"])
def predict():
    data = request.json

    so_ngay_du_kien = data["SoNgayDuKien"]
    do_kho = data["DoKho"]
    so_nguoi = data["SoNguoiThamGia"]

    prediction = model.predict([[so_ngay_du_kien, do_kho, so_nguoi]])

    return jsonify({
        "SoNgayTreDuDoan": round(float(prediction[0]), 2)
    })

# if __name__ == "__main__":
#     app.run(port=5000)
if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000)