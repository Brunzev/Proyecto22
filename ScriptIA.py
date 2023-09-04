import smtplib
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText
from email.mime.application import MIMEApplication
import pandas as pd
import joblib

def UsarModelo(Excel_a_Analizar):
    #Importamos el modelo
    print("Estamos usando el modelo")
    ModeloClf=joblib.load('arbol_entrenado.pkl')
    DataFrame=pd.read_excel(Excel_a_Analizar,sheet_name='Hoja1')
    vIndependientes = DataFrame.iloc[:,6:16]
    prediction = ModeloClf.predict(vIndependientes)
    DataFrame['LAVADODEACTIVOS'] = prediction
    NuevoExcel = 'datos_con_predicciones.xlsx'  # Ruta del archivo Excel generado
    DataFrame.to_excel(NuevoExcel, index=False)
    return NuevoExcel

# Lista de destinatarios (agrega las direcciones de correo que desees)
destinatarios = ['teresa.atencio.robles@hotmail.com', 'brunzev98@gmail.com']

def Enviar(Excel_a_Enviar):
    # Configuración del correo
    print("Estamos enviando")
    smtp_server = 'smtp.outlook.com'
    smtp_port = 587
    smtp_username = 'teresa_atencio@usmp.pe'
    smtp_password = '159875321t'
    sender_email = 'teresa_atencio@usmp.pe'
    #recipient_email = 'teresa.atencio.robles@hotmail.com'
    subject = 'Archivo con las transaciones sospechozas'
    message = 'Adjunto encontrarás el archivo con las predicciones.'

    # Crear el mensaje de correo
    msg = MIMEMultipart()
    msg['From'] = sender_email
    #msg['To'] = recipient_email
    msg['Subject'] = subject
    msg.attach(MIMEText(message, 'plain'))

    # Adjuntar el archivo Excel
    with open(Excel_a_Enviar, "rb") as excel_file:
         excel_attachment = MIMEApplication(excel_file.read(), _subtype="xlsx")
         excel_attachment.add_header('Content-Disposition', f'attachment; filename={Excel_a_Enviar}')
         msg.attach(excel_attachment)

    # Conectar y enviar el correo
    for recipient_email in destinatarios:
        msg['To'] = recipient_email
        try:
            server = smtplib.SMTP(smtp_server, smtp_port)
            server.starttls()
            server.login(smtp_username, smtp_password)
            server.sendmail(sender_email, recipient_email, msg.as_string())
            server.quit()
            print("Correo enviado exitosamente!")
        except Exception as e:
            print("Error al enviar el correo:", str(e))
