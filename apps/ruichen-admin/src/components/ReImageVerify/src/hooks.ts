import { ref, onMounted } from "vue";

/**
 * 绘制图形验证码
 * @param width - 图形宽度
 * @param height - 图形高度
 */
export const useImageVerify = (width = 120, height = 40) => {
  const domRef = ref<HTMLCanvasElement>();
  const imgCode = ref("");

  function setImgCode(code: string) {
    imgCode.value = code;
  }

  function getImgCode() {
    if (!domRef.value) return;
    imgCode.value = draw(domRef.value, width, height);
  }

  onMounted(() => {
    getImgCode();
  });

  return {
    domRef,
    imgCode,
    setImgCode,
    getImgCode
  };
};

function randomNum(min: number, max: number) {
  return Math.floor(Math.random() * (max - min) + min);
}

function randomColor(min: number, max: number) {
  const r = randomNum(min, max);
  const g = randomNum(min, max);
  const b = randomNum(min, max);
  return `rgb(${r},${g},${b})`;
}

function draw(dom: HTMLCanvasElement, width: number, height: number) {
  let imgCode = "";

  const ctx = dom.getContext("2d");
  if (!ctx) return imgCode;

  // 背景色优化：加深背景色，增强对比度
  const gradient = ctx.createLinearGradient(0, 0, width, height);
  gradient.addColorStop(0, "#8e9fff"); // 深蓝色
  gradient.addColorStop(1, "#6db2ff"); // 深青色
  ctx.fillStyle = gradient;
  ctx.fillRect(0, 0, width, height);

  // 随机选择验证码类型：字母或算术
  const type = randomNum(0, 2) === 0 ? "char" : "math";

  if (type === "char") {
    // 字母验证码
    const CHARACTERS =
      "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz23456789";
    for (let i = 0; i < 4; i += 1) {
      const text = CHARACTERS[randomNum(0, CHARACTERS.length)];
      imgCode += text;
      const fontSize = randomNum(22, 30);
      const deg = randomNum(-10, 10); // 减小旋转角度范围

      // 使用更美观的字体
      ctx.font = `${fontSize}px Arial, sans-serif`;
      ctx.textBaseline = "middle";
      ctx.fillStyle = randomColor(0, 100); // 更深色的字符

      // 添加阴影
      ctx.shadowColor = "rgba(0, 0, 0, 0.3)";
      ctx.shadowOffsetX = 1;
      ctx.shadowOffsetY = 1;
      ctx.shadowBlur = 2;

      ctx.save();
      ctx.translate(25 * i + 15, height / 2);
      ctx.rotate((deg * Math.PI) / 180);
      // 增加字符加粗效果
      ctx.lineWidth = 3;
      ctx.strokeStyle = randomColor(0, 100); // 加深的轮廓色
      ctx.strokeText(text, -10, 0); // 描边
      ctx.fillText(text, -10, 0); // 填充
      ctx.restore();
    }
  } else if (type === "math") {
    // 算术验证码
    const num1 = randomNum(1, 10);
    const num2 = randomNum(1, 10);
    const operator = ["+", "-", "×"][randomNum(0, 3)];
    let result = 0;
    switch (operator) {
      case "+":
        result = num1 + num2;
        break;
      case "-":
        result = num1 - num2;
        break;
      case "×":
        result = num1 * num2;
        break;
    }
    imgCode = result.toString();

    const text = `${num1} ${operator} ${num2} = ?`;
    const fontSize = 20;
    ctx.font = `${fontSize}px Arial, sans-serif`;
    ctx.textBaseline = "middle";
    ctx.fillStyle = randomColor(0, 100); // 更深色的字符
    // 描边并加粗
    ctx.lineWidth = 2;
    ctx.strokeStyle = randomColor(0, 100); // 加深的轮廓色
    ctx.strokeText(text, 10, height / 2);
    ctx.fillText(text, 10, height / 2);
  }

  // 绘制干扰线（更细且颜色更柔和）
  for (let i = 0; i < 3; i += 1) {
    ctx.beginPath();
    ctx.moveTo(randomNum(0, width), randomNum(0, height));
    ctx.lineTo(randomNum(0, width), randomNum(0, height));
    ctx.strokeStyle = randomColor(150, 180); // 浅色干扰线
    ctx.lineWidth = 0.5;
    ctx.stroke();
  }

  // 绘制干扰点（更少且颜色更柔和）
  for (let i = 0; i < 15; i += 1) {
    ctx.beginPath();
    ctx.arc(randomNum(0, width), randomNum(0, height), 1, 0, 2 * Math.PI);
    ctx.fillStyle = randomColor(150, 180); // 浅色干扰点
    ctx.fill();
  }

  return imgCode;
}
