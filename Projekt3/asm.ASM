format PE GUI 4.0 DLL
include 'win32a.inc'
section '.text' code readable executable


proc eros stdcall, matrices:DWORD, RGBvalues:DWORD, lenght:DWORD, mLenght:DWORD
     pusha
     mov ecx,[lenght]
     mov eax,[matrices]
     mov ebx,[RGBvalues]


erosion:
	mov edi,[mLenght]
check:
	cmp edi,0
	je koniec
	dec edi

	mov dl, byte [eax]
	mov byte [mVariable],dl
	cmp [mVariable],255
	je white
	add eax,1
	jmp check

whitening:
	mov dl,byte [variable2]
	mov byte [ebx],dl
	mov [RGBvalues], ebx
	jmp check

finish:
	add ebx,1
	loop erosion
	popa
	ret
endp




proc binar stdcall, Rvalues:DWORD, Gvalues:DWORD, Bvalues:DWORD, treshold:DWORD, lenght:DWORD
	pusha
	finit
	mov ecx,[lenght]
	mov eax,[Rvalues]
	mov ebx,[Gvalues]
	mov edi,[Bvalues]

binarization:
	;R
	mov dl,byte [eax]
	mov byte [R],dl
	;G
	mov dl,byte [ebx]
	mov byte [G],dl
	;B
	mov dl,byte [eax]
	mov byte [B],dl
	;L=0.3*R + 0.59*G + 0.11*B
	fild [R]
	fld [vR]
	fmulp
	fild [G]
	fld [vG]
	fmulp
	fild [B]
	fld [vB]
	fmulp
	faddp
	faddp
	fistp [L]
	mov edx,[L]
	cmp [treshold],edx
	ja white
	jmp black
white:
	;R = 0
	mov dl,byte [variable1]
	mov byte [eax],dl
	mov [Rvalues], eax
	;G = 0
	mov dl,byte [variable1]
	mov byte [ebx], dl
	mov [Gvalues], ebx
	;B = 0
	mov dl,byte [variable1]
	mov byte [edi], dl
	mov [Bvalues], edi
	jmp koniec
black:
	;R = 255
	mov dl,byte [variable2]
	mov byte [eax],dl
	mov [Rvalues], eax
	;G = 255
	mov dl,byte [variable2]
	mov byte [ebx], dl
	mov [Gvalues], ebx
	;B = 255
	mov dl,byte [variable2]
	mov byte [edi], dl
	mov [Bvalues], edi
	jmp koniec
koniec:
	add eax,1
	add ebx,1
	add edi,1
	dec ecx
	cmp ecx,0
	jne binarization
	popa
	ret
endp


proc dllOK stdcall
	invoke MessageBoxA, HWND_DESKTOP,_tresc,_tytul, MB_OK
	ret
endp

section '.data' data readable writeable
	R dd 0
	G dd 0
	B dd 0
	vR dq 0.3
	vG dq 0.59
	vB dq 0.11
	variable1 dd 0
	variable2 dd 255
	mVariable dd 0
	mL dd 0
	L dd 0
	_tytul db "OK", 0
	_tresc db "Biblioteka MojaDLL.dll jest dostêpna", 0

section '.idata' import data readable writeable
	library user32,'USER32.DLL'
	import user32,\
	MessageBoxA,'MessageBoxA'

section '.edata' export data readable
	export 'asm.DLL',\
	eros,'eros',\
	binar,'binar',\
	dllOK,'dllOK'

section '.reloc' fixups data readable discardable