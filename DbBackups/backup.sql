PGDMP     %    2        
        y            FoodService    12.4    12.4 -    K           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            L           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            M           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            N           1262    25252    FoodService    DATABASE     �   CREATE DATABASE "FoodService" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';
    DROP DATABASE "FoodService";
                postgres    false            �            1259    25766    AspNetRoleClaims    TABLE     �   CREATE TABLE public."AspNetRoleClaims" (
    "Id" integer NOT NULL,
    "RoleId" text NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);
 &   DROP TABLE public."AspNetRoleClaims";
       public         heap    admin    false            �            1259    25772    AspNetRoleClaims_Id_seq    SEQUENCE     �   ALTER TABLE public."AspNetRoleClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetRoleClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          admin    false    202            �            1259    25774    AspNetRoles    TABLE     �   CREATE TABLE public."AspNetRoles" (
    "Id" text NOT NULL,
    "Name" character varying(256),
    "NormalizedName" character varying(256),
    "ConcurrencyStamp" text
);
 !   DROP TABLE public."AspNetRoles";
       public         heap    admin    false            �            1259    25780    AspNetUserClaims    TABLE     �   CREATE TABLE public."AspNetUserClaims" (
    "Id" integer NOT NULL,
    "UserId" text NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);
 &   DROP TABLE public."AspNetUserClaims";
       public         heap    admin    false            �            1259    25786    AspNetUserClaims_Id_seq    SEQUENCE     �   ALTER TABLE public."AspNetUserClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetUserClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          admin    false    205            �            1259    25788    AspNetUserLogins    TABLE     �   CREATE TABLE public."AspNetUserLogins" (
    "LoginProvider" text NOT NULL,
    "ProviderKey" text NOT NULL,
    "ProviderDisplayName" text,
    "UserId" text NOT NULL
);
 &   DROP TABLE public."AspNetUserLogins";
       public         heap    admin    false            �            1259    25794    AspNetUserRoles    TABLE     b   CREATE TABLE public."AspNetUserRoles" (
    "UserId" text NOT NULL,
    "RoleId" text NOT NULL
);
 %   DROP TABLE public."AspNetUserRoles";
       public         heap    admin    false            �            1259    25800    AspNetUserTokens    TABLE     �   CREATE TABLE public."AspNetUserTokens" (
    "UserId" text NOT NULL,
    "LoginProvider" text NOT NULL,
    "Name" text NOT NULL,
    "Value" text
);
 &   DROP TABLE public."AspNetUserTokens";
       public         heap    admin    false            �            1259    25806    AspNetUsers    TABLE     I  CREATE TABLE public."AspNetUsers" (
    "Id" text NOT NULL,
    "UserName" character varying(256),
    "NormalizedUserName" character varying(256),
    "Email" character varying(256),
    "NormalizedEmail" character varying(256),
    "EmailConfirmed" boolean NOT NULL,
    "PasswordHash" text,
    "SecurityStamp" text,
    "ConcurrencyStamp" text,
    "PhoneNumber" text,
    "PhoneNumberConfirmed" boolean NOT NULL,
    "TwoFactorEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone,
    "LockoutEnabled" boolean NOT NULL,
    "AccessFailedCount" integer NOT NULL
);
 !   DROP TABLE public."AspNetUsers";
       public         heap    admin    false            �            1259    25812    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    admin    false            ?          0    25766    AspNetRoleClaims 
   TABLE DATA           W   COPY public."AspNetRoleClaims" ("Id", "RoleId", "ClaimType", "ClaimValue") FROM stdin;
    public          admin    false    202   d:       A          0    25774    AspNetRoles 
   TABLE DATA           [   COPY public."AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp") FROM stdin;
    public          admin    false    204   �:       B          0    25780    AspNetUserClaims 
   TABLE DATA           W   COPY public."AspNetUserClaims" ("Id", "UserId", "ClaimType", "ClaimValue") FROM stdin;
    public          admin    false    205   �;       D          0    25788    AspNetUserLogins 
   TABLE DATA           m   COPY public."AspNetUserLogins" ("LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId") FROM stdin;
    public          admin    false    207   �;       E          0    25794    AspNetUserRoles 
   TABLE DATA           ?   COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
    public          admin    false    208   �;       F          0    25800    AspNetUserTokens 
   TABLE DATA           X   COPY public."AspNetUserTokens" ("UserId", "LoginProvider", "Name", "Value") FROM stdin;
    public          admin    false    209   �<       G          0    25806    AspNetUsers 
   TABLE DATA           "  COPY public."AspNetUsers" ("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount") FROM stdin;
    public          admin    false    210   �<       H          0    25812    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          admin    false    211   r?       O           0    0    AspNetRoleClaims_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."AspNetRoleClaims_Id_seq"', 1, false);
          public          admin    false    203            P           0    0    AspNetUserClaims_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."AspNetUserClaims_Id_seq"', 1, false);
          public          admin    false    206            �
           2606    25816 $   AspNetRoleClaims PK_AspNetRoleClaims 
   CONSTRAINT     h   ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id");
 R   ALTER TABLE ONLY public."AspNetRoleClaims" DROP CONSTRAINT "PK_AspNetRoleClaims";
       public            admin    false    202            �
           2606    25818    AspNetRoles PK_AspNetRoles 
   CONSTRAINT     ^   ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."AspNetRoles" DROP CONSTRAINT "PK_AspNetRoles";
       public            admin    false    204            �
           2606    25820 $   AspNetUserClaims PK_AspNetUserClaims 
   CONSTRAINT     h   ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id");
 R   ALTER TABLE ONLY public."AspNetUserClaims" DROP CONSTRAINT "PK_AspNetUserClaims";
       public            admin    false    205            �
           2606    25822 $   AspNetUserLogins PK_AspNetUserLogins 
   CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey");
 R   ALTER TABLE ONLY public."AspNetUserLogins" DROP CONSTRAINT "PK_AspNetUserLogins";
       public            admin    false    207    207            �
           2606    25824 "   AspNetUserRoles PK_AspNetUserRoles 
   CONSTRAINT     t   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId");
 P   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "PK_AspNetUserRoles";
       public            admin    false    208    208            �
           2606    25826 $   AspNetUserTokens PK_AspNetUserTokens 
   CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name");
 R   ALTER TABLE ONLY public."AspNetUserTokens" DROP CONSTRAINT "PK_AspNetUserTokens";
       public            admin    false    209    209    209            �
           2606    25828    AspNetUsers PK_AspNetUsers 
   CONSTRAINT     ^   ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."AspNetUsers" DROP CONSTRAINT "PK_AspNetUsers";
       public            admin    false    210            �
           2606    25830 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            admin    false    211            �
           1259    25831 
   EmailIndex    INDEX     S   CREATE INDEX "EmailIndex" ON public."AspNetUsers" USING btree ("NormalizedEmail");
     DROP INDEX public."EmailIndex";
       public            admin    false    210            �
           1259    25832    IX_AspNetRoleClaims_RoleId    INDEX     _   CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON public."AspNetRoleClaims" USING btree ("RoleId");
 0   DROP INDEX public."IX_AspNetRoleClaims_RoleId";
       public            admin    false    202            �
           1259    25833    IX_AspNetUserClaims_UserId    INDEX     _   CREATE INDEX "IX_AspNetUserClaims_UserId" ON public."AspNetUserClaims" USING btree ("UserId");
 0   DROP INDEX public."IX_AspNetUserClaims_UserId";
       public            admin    false    205            �
           1259    25834    IX_AspNetUserLogins_UserId    INDEX     _   CREATE INDEX "IX_AspNetUserLogins_UserId" ON public."AspNetUserLogins" USING btree ("UserId");
 0   DROP INDEX public."IX_AspNetUserLogins_UserId";
       public            admin    false    207            �
           1259    25835    IX_AspNetUserRoles_RoleId    INDEX     ]   CREATE INDEX "IX_AspNetUserRoles_RoleId" ON public."AspNetUserRoles" USING btree ("RoleId");
 /   DROP INDEX public."IX_AspNetUserRoles_RoleId";
       public            admin    false    208            �
           1259    25836    RoleNameIndex    INDEX     \   CREATE UNIQUE INDEX "RoleNameIndex" ON public."AspNetRoles" USING btree ("NormalizedName");
 #   DROP INDEX public."RoleNameIndex";
       public            admin    false    204            �
           1259    25837    UserNameIndex    INDEX     `   CREATE UNIQUE INDEX "UserNameIndex" ON public."AspNetUsers" USING btree ("NormalizedUserName");
 #   DROP INDEX public."UserNameIndex";
       public            admin    false    210            �
           2606    25838 7   AspNetRoleClaims FK_AspNetRoleClaims_AspNetRoles_RoleId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetRoleClaims" DROP CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId";
       public          admin    false    202    2728    204            �
           2606    25843 7   AspNetUserClaims FK_AspNetUserClaims_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserClaims" DROP CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId";
       public          admin    false    205    210    2743            �
           2606    25848 7   AspNetUserLogins FK_AspNetUserLogins_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserLogins" DROP CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId";
       public          admin    false    2743    207    210            �
           2606    25853 5   AspNetUserRoles FK_AspNetUserRoles_AspNetRoles_RoleId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;
 c   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId";
       public          admin    false    208    204    2728            �
           2606    25858 5   AspNetUserRoles FK_AspNetUserRoles_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 c   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId";
       public          admin    false    2743    208    210            �
           2606    25863 7   AspNetUserTokens FK_AspNetUserTokens_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserTokens" DROP CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId";
       public          admin    false    209    2743    210            ?      x������ � �      A     x�%��NC1E�1J'v�'Q!�V����Ĉ�
���Z>��9y2��P�i��6r�����q�����&3f�р*�;�b�✾�c��C�-v�Y�(�K�|�[����r*6{��i\�]e�%WO����H2h�;ܻ�%H<�c*�����k��������\,d��i9ϥ�����b�\�o�R����yY�#7S��z���}�O��2W*e6"��ĵ�6V�����3����m�/v^�      B      x������ � �      D      x������ � �      E   �   x���ˍ1��\��q.{�`�aZ��^���,=o����
��u�QyV�Mq���B�8x� ��M��"c�LbRX�R��)x��Z��xhacFݵAv5D`A��.6玑���}�Rɚ�Z79#���P���r�2�M�A��S�&�+�J�tί�	7p�
+���4�}�_�7L�      F      x������ � �      G   �  x����n�0@�ʯ��E�t(J�fk�eYB/)�Kl�N�����@��9��7��.F`H*@�����XG5�XW��A��8L4q���Q����F���=zi:-�b:�ڠ���ܑ����D18�Sv
v']V)�so�K,�K��������3���׭���ĳ��%j���/_����,M������<_8Y8���aj�P�a�A0��b,5@*Jt�B�}M������w�JS��h	a8�X�2!�3�V�=�盌����f�����߯��M�V��x�O�8��zc=�y壺��aÿ��K���ܴa-$�[���'��y�|���W�U��]��:(h��:�Z�r"�x�F`o醢�2
�u (��=�����B]���4(`�^b)���V��P�FD��]��o{�y���}�cFcO��{Ja��ͤȎ~+�٫��a�S�eU��VMn]�ĉ�d{F��g����f��𑽎V�Sg>��a��XV��s/J���:Bq7٠�8d啝��e����;쨂�� D]w�&��
1AF����J���>�����[qI=�t�2����̫��cy0E �a���C���v{�vb�{�����5�^>��y;~�%���8s+Z�`m�|Z.��fl�����d���W ��$��ׇ���_Y�-h      H   '   x�320240303�4252����,�4�3�3����� m4p     