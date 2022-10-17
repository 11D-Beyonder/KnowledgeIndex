file=open("案例库.txt","r",encoding="utf-8")
out=open("content_res.txt","w",encoding="utf-8")
while True:
    line=file.readline()
    if line:
        line=line.strip()
        if not line.isdecimal() and line!="":
            out.write(line+"\n")
    else:
        break
out.close()
file.close()