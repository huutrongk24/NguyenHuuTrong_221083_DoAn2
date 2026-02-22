import pandas as pd
from sklearn.linear_model import LinearRegression
import joblib

# Dataset mô phỏng doanh nghiệp
data = {
    "SoNgayDuKien": [5, 10, 3, 7, 15, 20, 8, 12, 6, 18],
    "DoKho": [1, 3, 1, 2, 4, 5, 2, 3, 2, 5],
    "SoNguoiThamGia": [1, 2, 1, 2, 3, 4, 2, 3, 1, 4],
    "SoNgayTreThucTe": [0, 2, 0, 1, 4, 6, 1, 3, 0, 5]
}

df = pd.DataFrame(data)

X = df[["SoNgayDuKien", "DoKho", "SoNguoiThamGia"]]
y = df["SoNgayTreThucTe"]

model = LinearRegression()
model.fit(X, y)

joblib.dump(model, "linear_model.pkl")

print("Model trained successfully and saved as linear_model.pkl")