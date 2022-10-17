import numpy as np

titles = []
file = open("title_res.txt", "r", encoding="utf-8")
while True:
    line = file.readline()
    if line:
        line = line.strip()
        titles.append(line)
    else:
        break
file.close()


def is_title(line: str):
    for title in titles:
        if line.find(title) != -1:
            return True, title
    return False, ""


file = open("content_res.txt", "r", encoding="utf-8")
out = open("import_data.sql", "w", encoding="utf-8")
title = None
content = None
labels = None
all_label=set()
while True:
    line = file.readline()

    if line:
        line = line.strip()
        x, y = is_title(line)
        if x:
            if title is not None and content is not None and labels is not None:
                all_label=all_label|set(labels.split("、"))
                out.write(
                    f"INSERT INTO `incident`(`title`,`labels`,`content`) VALUES('{title}','{labels}','{content}');\n"
                )
            title = y
            content = None
            labels = None
        elif line.startswith("理论与概念："):
            labels = line.replace("理论与概念：", "")
        elif line.startswith("事件速览："):
            content = line.replace("事件速览：", "")
        else:
            if content is None:
                labels += line
            else:
                content += line
    else:
        all_label=all_label|set(labels.split("、"))
        out.write(
            f"INSERT INTO `incident`(`title`,`labels`,`content`) VALUES('{title}','{labels}','{content}');\n"
        )
        break
for label in all_label:
    out.write(f"INSERT INTO `label`(`name`,`color`) VALUES('{label}',{np.random.choice(a=[2,4,5,6,7,9])});\n")
file.close()
out.close()
