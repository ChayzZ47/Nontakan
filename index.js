const express = require('express');
const app = express();
const port = 3000;

app.use(express.json());

// สร้าง route แบบง่ายๆ
app.get('/', (req, res) => {
    res.send('Welcome to my Nontakan Website');
});

// สร้าง API เพื่อรับข้อมูลผู้ใช้
app.get('/api/users', (req, res) => {
    const users = [
        { id: 1, name: 'John Doe' },
        { id: 2, name: 'Jane Doe' },
    ];
    res.json(users);
});

// สร้าง API เพื่อเพิ่มผู้ใช้ใหม่
app.post('/api/users', (req, res) => {
    const newUser = req.body;
    // เพิ่มผู้ใช้ใหม่ลงในฐานข้อมูล (จำลอง)
    res.json({ message: 'User added', user: newUser });
});

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
