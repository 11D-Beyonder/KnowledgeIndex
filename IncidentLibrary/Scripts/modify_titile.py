import re

# 个别案例名称需要后期手动修改

file = open("案例名称.txt", "r", encoding="utf-8")
pattern = r"[1-2][0-9][0-9][0-9]\s[一-龥]+"
out=open("res.txt","w",encoding="utf-8")
while True:
    line = file.readline()
    if line:
        out.write(re.findall(pattern, line)[0]+"\n")
    else:
        break
file.close()
